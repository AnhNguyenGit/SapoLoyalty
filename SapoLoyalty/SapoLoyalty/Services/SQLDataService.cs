using SapoLoyalty.DomainObject;
using SapoLoyalty.EFConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace SapoLoyalty.Services
{
    public class SQLDataService<TEntity> : ISQLDataService<TEntity> where TEntity : BaseEntity
    {
        private IRepository<TEntity> _repository;
        public IRepository<TEntity> Repository { get { return _repository; } }
        public SQLDataService()
        {
            _repository = new Repository<TEntity>();
        }
        public ICollection<TEntity> All()
        {
            var res = _repository.GetAll();

            return res;
        }

        public TEntity GetById(int id)
        {
            try {
                return _repository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            
            _repository.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public TEntity Find(List<Expression<Func<TEntity, bool>>> expressions)
        {
            return _repository.Find(expressions);
        }
        public ICollection<TEntity> Find(Expression<Func<TEntity,bool>> expression)
        {
            return _repository.Find(expression);
        }
        public ICollection<TEntity> FindMany(List<Expression<Func<TEntity, bool>>> expressions)
        {
            return _repository.FindMany(expressions);
        }

        public int Count(Expression<Func<TEntity, bool>> expression =null)
        {
            
            return _repository.Count(expression);
        }
    }
}