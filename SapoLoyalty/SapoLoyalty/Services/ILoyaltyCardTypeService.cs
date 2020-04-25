using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Services
{
    public interface ILoyaltyCardTypeService:ISQLDataService<LoyaltyCardType>
    {
        LoyaltyCardType GetBySpent(long Spent);
    }
}