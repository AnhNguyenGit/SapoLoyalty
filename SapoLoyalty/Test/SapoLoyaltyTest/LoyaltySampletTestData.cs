using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapoLoyaltyTest
{
    public static  class LoyaltySampletTestData
    {
        public static ICollection<LoyaltyCard> Cards = new List<LoyaltyCard>
        {
            new LoyaltyCard { Id = 1, Code = "LT001", LoyaltyCardTypeId = 1, Point=23.45f, TotalSpent = 2345000, StartDate = new DateTime(2019,12,18), CreatedOn = new DateTime(2019, 12,18), ModifiedOn=new DateTime(2019, 12,18)  },
            new LoyaltyCard { Id = 2, Code = "LT002", LoyaltyCardTypeId = 2, Point=0, TotalSpent = 7987000, StartDate = new DateTime(2019,12,18), CreatedOn = new DateTime(2019, 12,18), ModifiedOn=new DateTime(2019, 12,18)  },
            new LoyaltyCard { Id = 3, Code = "LT003", LoyaltyCardTypeId = 3, Point=-12, TotalSpent = 15400000, StartDate = new DateTime(2019,12,18), CreatedOn = new DateTime(2019, 12,18), ModifiedOn=new DateTime(2019, 12,18)  },
        };

        public static ICollection<Transaction> Transactions = new List<Transaction>
        {
             new Transaction() { Id=1,LoyaltyCardId=1,PointAdjust=30.4f, SpentAdjust = 3040000, CreatedOn = new System.DateTime(2019,12,18) }
        };
    }
}
