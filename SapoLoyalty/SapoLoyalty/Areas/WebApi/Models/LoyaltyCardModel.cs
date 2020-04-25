using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Areas.WebApi.Models
{
    public class LoyaltyCardModel : BaseModel, IModel<LoyaltyCard>
    {
        public LoyaltyCardModel() {
           
        }
        public LoyaltyCardModel(LoyaltyCard card)
        {
            Code = card.Code;
            Id = card.Id;
            Phone = card.Phone;
            Point = card.Point;
            TotalSpent = card.TotalSpent;           
            ModifiedOn = card.ModifiedOn;
            StartDate = card.StartDate;
            EndDate = card.EndDate;
            LoyaltyCardTypeId = card.LoyaltyCardTypeId;
            CreatedOn = card.CreatedOn;

        }
        public string Code { get; set; }
        [Required]
        public int Phone { get; set; }
        public int? LoyaltyCardTypeId { get; set; }
        public double Point { get; set; }
        public long TotalSpent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public LoyaltyCard ToEnity()
        {
            return new LoyaltyCard()
            {
                Id = Id,
                Code = Code,
                Phone = Phone,
                StartDate = StartDate,
                EndDate = EndDate,
                Point = Point,
                TotalSpent = TotalSpent,
                CreatedOn = CreatedOn,
                ModifiedOn = ModifiedOn,
                LoyaltyCardTypeId = LoyaltyCardTypeId
            };
        }
    }
}