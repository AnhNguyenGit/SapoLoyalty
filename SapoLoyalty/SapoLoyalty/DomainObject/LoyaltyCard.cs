using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.DomainObject
{
    public class LoyaltyCard : BaseEntity
    {
        private ICollection<Transaction> _transactions { get; set; }
        public string Code { get; set; }
        public int Phone { get; set; }
        public int? LoyaltyCardTypeId { get; set; }
        public double Point { get; set; }
        public long TotalSpent {get;set;}
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        #region navigation
        public virtual LoyaltyCardType LoyaltyCardType { get;set;}
        public virtual ICollection<Transaction> Transactions {
            get { return _transactions ?? (_transactions =  new List<Transaction>()); }

            set { _transactions = value; } }
        #endregion
    }
}