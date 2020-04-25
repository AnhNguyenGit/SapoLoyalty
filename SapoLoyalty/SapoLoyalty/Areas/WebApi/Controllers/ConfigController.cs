using SapoLoyalty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SapoLoyalty.Areas.WebApi.Models;
using SapoLoyalty.DomainObject;

namespace SapoLoyalty.Areas.WebApi.Controllers
{
    public class ConfigController : BaseApiController
    {
       
        private readonly ISQLDataService<Config> _configService;
        public ConfigController( ISQLDataService<Config> configService)
        {
           
            _configService = configService;
           
        }
        [HttpGet]
        [Route("api/config")]
        public JsonMessageModel Get(string access_token=null)
        {
            if (!AuthorizeAccessToken(access_token).success)
                return AuthorizeAccessToken(access_token);
           var configs = _configService.All();
           return new JsonMessageModel() { success = true, statusCode = (int)HttpStatusCode.OK, data = configs?.Select(x => new ConfigModel(x)) };
        
        }
        /// <summary>
        /// Api them cau hinh tich diem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/config")]
        public JsonMessageModel Post(ConfigModel model, string access_token = null)
        {
            if (!AuthorizeAccessToken(access_token).success)
                return AuthorizeAccessToken(access_token);
            try
            {
                if(!ModelState.IsValid)
                    return new JsonMessageModel { success = false, statusCode = (int)HttpStatusCode.ExpectationFailed, message = "Model state not Valid" };
                var activeConfigs = _configService.Find(x => x.Active);
                var config = model.ToEnity();
                config.Active = true;
                config.CreatedOn = DateTime.UtcNow;
                _configService.Insert(config);
                if(activeConfigs!=null&& activeConfigs.Any())
                {
                    foreach(var active in activeConfigs)
                    {
                        active.Active = false;
                        _configService.Update(active);
                    }
                }
                return new JsonMessageModel { success = true, statusCode = (int) HttpStatusCode.OK, message = "New Config is created!", data   = config.Id };
            }
            catch (Exception  e)
            {
                return ExceptionReturnMessage(e);
            }
        }
        /// <summary>
        /// API dieu  chinh cau hinh tich diem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/config")]
        public JsonMessageModel Put(ConfigModel model, string access_token = null)
        {
            if (!AuthorizeAccessToken(access_token).success)
                return AuthorizeAccessToken(access_token);
            try
            {
                if (!ModelState.IsValid)
                    return new JsonMessageModel { success = false, statusCode = (int)HttpStatusCode.ExpectationFailed, message = "Model state not Valid" };
                var id = model.GetType().GetProperty("Id").GetValue(model);
                var config = _configService.GetById(Int32.Parse(id.ToString()));
                if(config == null)
                    return new JsonMessageModel { success = false, statusCode = (int)HttpStatusCode.ExpectationFailed, message = "Entity Not Found!" };
                model.CreatedOn = config.CreatedOn;
                config = model.ToEnity();
                _configService.Update(config);
                return new JsonMessageModel {success = true, statusCode = (int) HttpStatusCode.OK, message = "New Config is updated!", data = config.Id };
            }
            catch (Exception e)
            {
                return ExceptionReturnMessage(e);
            }
        }
        [HttpGet]
        [Route("api/config/{id}")]
        public JsonMessageModel Get(int id, string access_token = null)
        {
            if (!AuthorizeAccessToken(access_token).success)
                return AuthorizeAccessToken(access_token);
            var config = _configService.GetById(id);

            return new JsonMessageModel { success = true, statusCode = (int)HttpStatusCode.OK, data = new ConfigModel(config) };
        }

        [HttpDelete]
        [Route("api/config/{id}")]
        [HttpPost]
        [Route("api/config/delete/{id}")]
        public JsonMessageModel Delete(int id, string access_token = null)
        {
            try
            {
                if (!AuthorizeAccessToken(access_token).success)
                    return AuthorizeAccessToken(access_token);
                var entity = _configService.GetById(id);
                if (entity != null)
                {
                    _configService.Delete(entity);
                    return new JsonMessageModel() { success = true, statusCode = (int)HttpStatusCode.OK, message = "Delete Config Successful" };
                }

                return new JsonMessageModel() { success = true, statusCode = (int)HttpStatusCode.InternalServerError, message = "Delelte Entity Fail" };

            }
            catch(Exception e)
            {
                return ExceptionReturnMessage(e);
            }

        }
    }
}
