using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SapoLoyalty.DomainObject;
using SapoLoyalty.EFConfiguration;

namespace SapoLoyalty.Services
{
    public class LoyaltyCardTypeService : ILoyaltyCardTypeService
    {
        private readonly IRepository<LoyaltyCardType> _repository;
        private readonly ISQLDataService<Config> _configService;
        public LoyaltyCardTypeService(ISQLDataService<Config> _configService)
        {
            this._configService = _configService;
            _repository = new Repository<LoyaltyCardType>();
        }
        public ICollection<LoyaltyCardType> All()
        {
            var query = _repository.Table;
            return query.ToList();
        }

        public int Count(Expression<Func<LoyaltyCardType, bool>> expression = null)
        {
            return _repository.Count();
        }

        public void Delete(LoyaltyCardType entity)
        {
             _repository.Delete(entity);
        }

        public ICollection<LoyaltyCardType> Find(Expression<Func<LoyaltyCardType, bool>> expression)
        {
            return _repository.Find(expression);
        }

        public LoyaltyCardType Find(List<Expression<Func<LoyaltyCardType, bool>>> expressions)
        {
            return _repository.Find(expressions);
        }

        public ICollection<LoyaltyCardType> FindMany(List<Expression<Func<LoyaltyCardType, bool>>> expressions)
        {
          return  _repository.FindMany(expressions);
        }

        public LoyaltyCardType GetById(int id)
        {
            return _repository.GetById(id);
        }

        public LoyaltyCardType GetBySpent(long Spent)
        {
            var query = _repository.Table;
            var subquery = query.Where(x => x.SpentThreshold <= Spent);
            try{
                //The co hang thap nhat
                if (subquery.Count() == 0)
                {
                    var min = query.Min(x => x.SpentThreshold);
                    return query.FirstOrDefault(x => x.SpentThreshold == min);
                }
                else
                {
                    var max = subquery.Max(x => x.SpentThreshold);
                    return subquery.FirstOrDefault(x => x.SpentThreshold == max);
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void Insert(LoyaltyCardType entity)
        {
            _repository.Insert(entity);
        }

        public void Update(LoyaltyCardType entity)
        {
            _repository.Update(entity);
        }
    }
}