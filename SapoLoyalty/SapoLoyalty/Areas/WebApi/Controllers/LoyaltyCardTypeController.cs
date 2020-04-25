using SapoLoyalty.Areas.WebApi.Models;
using SapoLoyalty.DomainObject;
using SapoLoyalty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SapoLoyalty.Areas.WebApi.Controllers
{
    public class LoyaltyCardTypeController : ApiController
    {
        private ISQLDataService<LoyaltyCardType> _loyaltyCardTypeService;

        public LoyaltyCardTypeController(ISQLDataService<LoyaltyCardType> loyaltyCardTypeService)
        {
            _loyaltyCardTypeService = loyaltyCardTypeService;
        }
        [Route("api/cardtype")]
        [Route("api/cardtype/get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
           
            try
            {
                var cardTypes = _loyaltyCardTypeService.All();
                return Request.CreateResponse(HttpStatusCode.OK, cardTypes?.Select(x=>new LoyaltyCardTypeModel(x)));
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/cardtype/id")]
        [Route("api/cardtype/get/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                var cardType = _loyaltyCardTypeService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, cardType!=null ? new LoyaltyCardTypeModel(cardType):null);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [Route("api/cardtype")]
        [Route("api/cardtype/post")]
        [HttpPost]
        public HttpResponseMessage Post(LoyaltyCardTypeModel model )
        {
            try
            {
                var cardType = model.ToEnity();
                cardType.CreatedOn = DateTime.UtcNow;                
                _loyaltyCardTypeService.Insert(cardType);
                return Request.CreateResponse(HttpStatusCode.OK, $"CardType {cardType.Id} is Created!");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);

            }
        }
    }
}
