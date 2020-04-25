using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapoLoyalty.Test
{
    public static class LoyaltySampleDataTest
    {
        public static  List<LoyaltyCard> LoyaltyCards = new List<LoyaltyCard>()
        {
            new LoyaltyCard { Id = 1, Code = "LT0001", Phone = 987654321, LoyaltyCardTypeId = 1, Point = 23.45, TotalSpent = 2345000, StartDate = new DateTime(2019, 12, 18), EndDate = new DateTime (2020,12,18), CreatedOn = new  DateTime(2019, 12, 18), ModifiedOn = new  DateTime(2019, 12, 18) },
            new LoyaltyCard { Id = 1, Code = "LT0002", Phone = 987654322, LoyaltyCardTypeId = 2, Point = 0, TotalSpent = 2345000, StartDate = new DateTime(2019, 10, 17), EndDate = new DateTime (2020,10,17), CreatedOn = new  DateTime(2019, 5, 17), ModifiedOn = new  DateTime(2019, 12, 17) },
            new LoyaltyCard { Id = 1, Code = "LT0003", Phone = 987654323, LoyaltyCardTypeId = 3, Point = -12, TotalSpent = 2345000, StartDate = new DateTime(2019, 11, 12), EndDate = new DateTime (2020,11,12), CreatedOn = new  DateTime(2019, 4, 25), ModifiedOn = new  DateTime(2019, 11, 27) },
            new LoyaltyCard { Id = 1, Code = "HT0001", Phone = 987654324, LoyaltyCardTypeId = 4, Point = 30, TotalSpent = 2345000, StartDate = new DateTime(2019, 5, 23), EndDate = new DateTime (2020,5,23), CreatedOn = new  DateTime(2019, 3, 12), ModifiedOn = new  DateTime(2019, 8, 23) },
            new LoyaltyCard { Id = 1, Code = "HT0002", Phone = 987654325, LoyaltyCardTypeId = 5, Point = 39, TotalSpent = 2345000, StartDate = new DateTime(2019, 7, 27), EndDate = new DateTime (2020,7,27), CreatedOn = new  DateTime(2019, 2, 1), ModifiedOn = new  DateTime(2019, 11, 27) }
        };
        public static List<LoyaltyCardType> LoyaltyCardTypes = new List<LoyaltyCardType>()
        {
            new LoyaltyCardType { Id=1, Name= "Thẻ chuẩn", SpentThreshold = 0, Duration = 365, DiscountPercent = 1, CreatedOn = new DateTime(2019, 12, 18), ModifiedOn = new DateTime(2019,12,18)},
            new LoyaltyCardType { Id=2, Name= "Thẻ bạc", SpentThreshold = 5000000, Duration = 365, DiscountPercent = 2, CreatedOn = new DateTime(2019, 12, 18), ModifiedOn = new DateTime(2019,12,18)},
            new LoyaltyCardType { Id=3, Name= "Thẻ vàng", SpentThreshold = 10000000, Duration = 365, DiscountPercent = 5, CreatedOn = new DateTime(2019, 12, 18), ModifiedOn = new DateTime(2019,12,18)},
            new LoyaltyCardType { Id=4, Name= "Thẻ bạc kim", SpentThreshold = 20000000, Duration = 365, DiscountPercent = 7, CreatedOn = new DateTime(2019, 12, 18), ModifiedOn = new DateTime(2019,12,18)},
             new LoyaltyCardType { Id=5, Name= "Thẻ kim cương", SpentThreshold = 50000000, Duration = 365, DiscountPercent = 10, CreatedOn = new DateTime(2019, 12, 18), ModifiedOn = new DateTime(2019,12,18)},
        };
        public static List<Transaction> Transactions = new List<Transaction>()
        {
            new Transaction {   Id = 1,     LoyaltyCardId = 1,  PointAdjust = 30.4,     SpentAdjust = 3040000,  CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 2,     LoyaltyCardId = 1,  PointAdjust = 2,    SpentAdjust = 200109,   CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 3,     LoyaltyCardId = 2,  PointAdjust = -30,  SpentAdjust = -3000000,     CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 4,     LoyaltyCardId = 4,  PointAdjust = -30,  SpentAdjust = -3000000,     CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 5,     LoyaltyCardId = 3,  PointAdjust = 10,   SpentAdjust = 1000000,  CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 6,     LoyaltyCardId = 5,  PointAdjust = -50,  SpentAdjust = -5000000,     CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 7,     LoyaltyCardId = 2,  PointAdjust = 61.04,    SpentAdjust = 6104000,  CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 8,     LoyaltyCardId = 3,  PointAdjust = 2,    SpentAdjust = 2004,     CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 9,     LoyaltyCardId = 1,  PointAdjust = -30.4,    SpentAdjust = -3040000,     CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 10,    LoyaltyCardId = 5,  PointAdjust = 21,   SpentAdjust = 2100000,  CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 11,    LoyaltyCardId = 3,  PointAdjust = 1.99,     SpentAdjust = 199000,  CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 12,    LoyaltyCardId = 1,  PointAdjust = 21,   SpentAdjust = 2600000,  CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 13,    LoyaltyCardId = 4,  PointAdjust = -70,  SpentAdjust = -7000000,     CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 14,    LoyaltyCardId = 5,  PointAdjust = 3,    SpentAdjust = 300000,  CreatedOn = new DateTime(2019, 12, 18)  }   ,
            new Transaction {   Id = 15,    LoyaltyCardId = 3,  PointAdjust = 10,   SpentAdjust = 1000000,  CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 16,    LoyaltyCardId = 1,  PointAdjust = 53,   SpentAdjust = 5300000,  CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 17,    LoyaltyCardId = 2,  PointAdjust = 1.05,     SpentAdjust = 105000,  CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 18,    LoyaltyCardId = 3,  PointAdjust = 50,   SpentAdjust = 5000000,  CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 19,    LoyaltyCardId = 4,  PointAdjust = -10,  SpentAdjust = -1000000,     CreatedOn = new DateTime(2019, 12, 19)  }   ,
            new Transaction {   Id = 20,    LoyaltyCardId = 5,  PointAdjust = 2.04,     SpentAdjust = 204000,  CreatedOn = new DateTime(2019, 12, 18)  }







        };
        public static List<Config> Configs = new List<Config>()
        {
            new Config { Id = 1, ConfigValue =100, Active = true }
        };
    }
}
