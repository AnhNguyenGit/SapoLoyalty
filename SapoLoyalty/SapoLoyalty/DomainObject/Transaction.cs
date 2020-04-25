using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.DomainObject
{
    public class Transaction : BaseEntity
    {
        public int LoyaltyCardId { get; set; }
        public double PointAdjust { get; set; }
        public long SpentAdjust { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual LoyaltyCard Card { get; set; }

    }
}