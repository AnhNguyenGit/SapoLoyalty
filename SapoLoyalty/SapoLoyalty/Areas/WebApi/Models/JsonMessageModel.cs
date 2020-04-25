using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapoLoyalty.Areas.WebApi.Models
{
    public class JsonMessageModel
    {
       public bool success { get; set; }
       public int statusCode { get; set; }
       public string message { get; set; }
       public object data { get; set; }
    }
}