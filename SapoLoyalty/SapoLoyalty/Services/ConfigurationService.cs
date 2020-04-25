using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetSetting(string key)
        {
            var AppSettings = System.Configuration.ConfigurationSettings.AppSettings;
            if (AppSettings.AllKeys.Contains(key))
                return AppSettings[key];
            return null;
        }
    }
}