using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SapoLoyalty.DomainObject;
using SapoLoyalty.EFConfiguration;

namespace SapoLoyalty.Services
{
    public class LoyaltyConfigService : ILoyaltyConfigService
    {
        private readonly IRepository<Config> _repository;
        public LoyaltyConfigService()
        {
            _repository = new Repository<Config>();
        }
        public ICollection<Config> All()
        {
            return _repository.Table?.ToList();
        }

        public int Count(Expression<Func<Config, bool>> expression = null)
        {
            return _repository.Count();
        }

        public void Delete(Config entity)
        {
            _repository.Delete(entity);
        }

        public ICollection<Config> Find(Expression<Func<Config, bool>> expression)
        {
            return _repository.Find(expression);
        }

        public Config Find(List<Expression<Func<Config, bool>>> expressions)
        {
            throw new NotImplementedException();
        }

        public ICollection<Config> FindMany(List<Expression<Func<Config, bool>>> expressions)
        {
            throw new NotImplementedException();
        }

        public Config GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Config entity)
        {
           
            throw new NotImplementedException();
        }

        public void Update(Config entity)
        {
            throw new NotImplementedException();
        }
    }
}