using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.DomainObject
{
    public class Config  : BaseEntity
    {
        public Config()
        {
            ConfigValue = 0;
        }
        public int ConfigValue { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
   
    }
}