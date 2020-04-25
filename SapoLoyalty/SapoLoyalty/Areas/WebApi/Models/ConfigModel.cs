using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Areas.WebApi.Models
{

    public class ConfigModel : BaseModel, IModel<Config>
    {
        #region propeties
        [Required(ErrorMessage = "ConfigValue is required!")]        
        public int ConfigValue { get; set; }        
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion
        #region ctor
        public ConfigModel()
        {

        }
        public ConfigModel(Config config)
        {
            this.Id = config.Id;
            this.ConfigValue = config.ConfigValue;
            this.CreatedOn = config.CreatedOn;
            this.Active = config.Active;
        }
        #endregion
        
        #region method
            public Config ToEnity()
            {
                return new Config()
                {
                    Id = this.Id,
                    ConfigValue = this.ConfigValue,
                    Active = this.Active,
                    CreatedOn = this.CreatedOn,

                };
            }

        #endregion
       

    }
}