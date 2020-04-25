using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace SapoLoyalty.EFConfiguration
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private LoyaltyDbContext _dbContext;
        private IDbSet<TEntity> _entities;
        public Repository()
        {
            _dbContext = new LoyaltyDbContext("name=LoyaltyDb");
        }
        public Repository(string nameOrConnectionString)
        {
            _dbContext = new LoyaltyDbContext(nameOrConnectionString);
        }

        public ICollection<TEntity> GetAll()
        {
            
            return Entities?.ToList();
        }

        public TEntity GetById(int Id)
        {
           return Entities.Find(Id);
        }

        public void Insert(TEntity entity) 
        {
            try
            {
                Entities.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(TEntity entity) 
        {
            try
            {
                var currentEntity = Entities.SingleOrDefault(x => x.Id == entity.Id);
                _dbContext.Entry(currentEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();          
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }
        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            _dbContext.SaveChanges();

        }

        public TEntity Find(List<Expression<Func<TEntity, bool>>> expressions)
        {
            return expressions.Aggregate(Entities.AsQueryable(),
                                  (current, expression) => current.Where(expression)).FirstOrDefault();
        }

        public ICollection<TEntity> FindMany(List<Expression<Func<TEntity, bool>>> expressions)
        {
            return expressions.Aggregate(Entities.AsQueryable(),
                                  (current, expression) => current.Where(expression))?.ToList();
        }

        public int Count(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
                return Entities.Where(expression).Count();
            return Entities.Count();
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            
            return Entities?.Where(expression)?.ToList();
        }

        public IDbSet<TEntity> Entities
        {
            get {
                if (_entities == null)
                    return _dbContext.Set<TEntity>();
                return _entities;
            }
         
        }

        public virtual IQueryable<TEntity> Table {
                get
                {
                    return Entities;
                }
           }
    }
}