using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.DomainObject
{
    public class LoyaltyCardType : BaseEntity
    {
        private  ICollection<LoyaltyCard> _loyaltyCards {get;set;}
        public string Name { get; set; }
        public long? SpentThreshold { get; set; }
        public int Duration { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<LoyaltyCard> LoyaltyCards { get {
                return _loyaltyCards ??( _loyaltyCards = new List<LoyaltyCard>());
            }
            set {
                _loyaltyCards = value;
            }
        }
    }
}