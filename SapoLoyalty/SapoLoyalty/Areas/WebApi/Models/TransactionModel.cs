using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Areas.WebApi.Models
{
    public class TransactionModel : BaseModel, IModel<Transaction>
    {
        #region Propeties
        [Required]        
        public int LoyaltyCardId { get; set; }
        public double PointAdjust { get; set; }
        public long SpentAdjust { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion

        #region ctor
        public TransactionModel( Transaction trade)
        {
            this.Id = trade.Id;
            this.SpentAdjust = trade.SpentAdjust;
            this.PointAdjust = trade.PointAdjust;
            this.LoyaltyCardId = trade.LoyaltyCardId;
            this.CreatedOn = this.CreatedOn;
        }

        public TransactionModel() {  }
        #endregion

        public Transaction ToEnity()
        {
            return new Transaction()
            {
                Id = this.Id,
                LoyaltyCardId = this.LoyaltyCardId,
                PointAdjust = this.PointAdjust,
                SpentAdjust = this.SpentAdjust,
                CreatedOn = this.CreatedOn
            };
        }


    }
}