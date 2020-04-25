using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SapoLoyalty.Services
{
   public interface ISQLDataService <TEntity> where TEntity:BaseEntity
    {
       /// <summary>
       ///  Get All Entity in Database
       /// </summary>
       /// <returns>Entity</returns>
        ICollection<TEntity> All();
        /// <summary>
        /// Get Entiy ById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);
        /// <summary>
        /// Create new Entity
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);
        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
        TEntity Find(List<Expression<Func<TEntity, bool>>> expressions);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        ICollection<TEntity> FindMany(List<Expression<Func<TEntity, bool>>> expressions);
        int Count(Expression<Func<TEntity, bool>> expression = null);    
    }
}
