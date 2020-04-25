using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SapoLoyalty.EFConfiguration
{
   public interface IRepository<TEntity> where TEntity:BaseEntity
    {
        IQueryable<TEntity> Table { get; }
        ICollection<TEntity> GetAll();
        TEntity GetById(int Id);
        TEntity Find(List<Expression<Func<TEntity, bool>>> expressions);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        ICollection<TEntity> FindMany(List<Expression<Func<TEntity, bool>>> expressions);
        void Insert(TEntity entity);
        void Update(TEntity enity);
        void Delete(TEntity enity);
        int Count(Expression<Func<TEntity,bool>> expression = null);
    }
}
