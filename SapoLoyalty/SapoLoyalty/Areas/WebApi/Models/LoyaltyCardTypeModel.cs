using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Areas.WebApi.Models
{
    public class LoyaltyCardTypeModel : BaseModel, IModel<LoyaltyCardType>
    {
        public string Name { get; set; }
        public long? SpentThreshold { get; set; }
        public int Duration { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public LoyaltyCardTypeModel() { }
        public LoyaltyCardTypeModel(LoyaltyCardType cardType)
        {
            Id = cardType.Id;
            Name = cardType.Name;
            SpentThreshold = cardType.SpentThreshold;
            Duration = cardType.Duration;
            DiscountPercent = cardType.DiscountPercent;
            CreatedOn = cardType.CreatedOn;
            ModifiedOn = cardType.ModifiedOn;
        }

        public LoyaltyCardType ToEnity()
        {
            return new LoyaltyCardType
            {
                Name = Name,
                SpentThreshold = SpentThreshold,
                Duration = Duration,
                DiscountPercent = DiscountPercent,
                CreatedOn = CreatedOn,
                ModifiedOn = ModifiedOn

            };
        }

        
    }
}