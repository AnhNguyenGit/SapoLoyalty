using Autofac;
using SapoLoyalty.Areas.WebApi.Models;
using SapoLoyalty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SapoLoyalty.Areas.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly  string TokeValidate = "Osr1F6FzEHHRkZTR1Tn6BL6jeWH4kN3X";
        private readonly IConfigurationService _configurationService;
        public BaseApiController()
        {
        }         

        [NonAction]
        public JsonMessageModel AuthorizeAccessToken(string tokenkey )
        {
            if (string.IsNullOrEmpty(tokenkey))
                return new JsonMessageModel() { success = false, message = "Access_token is required", statusCode = (int)HttpStatusCode.Unauthorized };
            if (!TokeValidate.Equals(tokenkey))
                return new JsonMessageModel() { success = false, message = "Acces_token InValid", statusCode = (int)HttpStatusCode.Unauthorized };
            return new JsonMessageModel() { success = true};
        }
        [NonAction]
        public JsonMessageModel ExceptionReturnMessage(Exception e)
        {
            return new JsonMessageModel { success = false, statusCode = (int)HttpStatusCode.BadRequest, data = e };

        }
        public string GetAccessTokenSetting()
        {
            string token =  System.Configuration.ConfigurationSettings.AppSettings["api_access_token"].ToString();
            return token;
        }
    }
}
