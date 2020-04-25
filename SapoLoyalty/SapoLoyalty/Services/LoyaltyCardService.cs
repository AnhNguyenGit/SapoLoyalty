using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using SapoLoyalty.EFConfiguration;

namespace SapoLoyalty.Services
{
    public class LoyaltyCardService : ILoyaltyCardService
    {
        private readonly IRepository<LoyaltyCard> _repository;
        private readonly ILoyaltyCardTypeService _loyaltyCardTypeService;
        private readonly ISQLDataService<Config> _config;

        public LoyaltyCardService( ILoyaltyCardTypeService loyaltyCardTypeService )
        {
            _repository = new Repository<LoyaltyCard>();
            _loyaltyCardTypeService = loyaltyCardTypeService;
        }
        public ICollection<LoyaltyCard> All()
        {
            var query = _repository.Table;
            return query.ToList();
        }

        public void Delete(LoyaltyCard entity)
        {
            _repository.Delete(entity);
        }

        public LoyaltyCard Find(List<Expression<Func<LoyaltyCard, bool>>> expressions)
        {
            return _repository.Find(expressions);
        }

        public ICollection<LoyaltyCard> FindMany(List<Expression<Func<LoyaltyCard, bool>>> expressions)
        {
            return _repository.FindMany(expressions);
        }

        public LoyaltyCard GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(LoyaltyCard entity)
        {
            bool emptyCode = string.IsNullOrEmpty(entity.Code);
            if (emptyCode)
                entity.Code = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
            _repository.Insert(entity);
            if (emptyCode)
            {
                string Code = string.Format("LT{0:0000}", entity.Id);
                entity.Code = Code;
                _repository.Update(entity);
            }
        }

        public void Update(LoyaltyCard entity)
        {
            LoyaltyCardType CardType = entity.LoyaltyCardType;
            var TotalSpent = entity.TotalSpent;
            var SpentThreshold = CardType.SpentThreshold;
            //so tien tich diem vuot qua nguong cua the           
            CardType = _loyaltyCardTypeService.GetBySpent(TotalSpent);
            if(entity.LoyaltyCardTypeId!=CardType.Id)
                entity.LoyaltyCardTypeId = CardType.Id; 
            _repository.Update(entity);
        }

     

        public int Count(Expression<Func<LoyaltyCard, bool>> expression)
        {
           return _repository.Count(expression);
        }

        public ICollection<LoyaltyCard> Find(Expression<Func<LoyaltyCard, bool>> expression)
        {
            return _repository.Find(expression);
        }

        
    }

}