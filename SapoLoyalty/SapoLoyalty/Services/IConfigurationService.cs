using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapoLoyalty.Services
{
    public  interface IConfigurationService
    {
        string GetSetting(string key);
    }
}
