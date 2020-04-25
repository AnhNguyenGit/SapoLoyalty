using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapoLoyalty.Areas.WebApi.Models
{
    public interface IModel<Entity> where Entity:BaseEntity
    {
        Entity ToEnity();
    }
}
