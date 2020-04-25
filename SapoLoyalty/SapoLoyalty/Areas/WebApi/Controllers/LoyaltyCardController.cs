using SapoLoyalty.Areas.WebApi.Models;
using SapoLoyalty.DomainObject;
using SapoLoyalty.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace SapoLoyalty.Areas.WebApi.Controllers
{
    
    public class LoyaltyCardController : ApiController
    {
        private readonly ILoyaltyCardService _loyaltyCardService;
        private readonly ISQLDataService<LoyaltyCardType> _loyaltyCardTypeService;
        public LoyaltyCardController(
            ILoyaltyCardService loyaltyCardService,
            ISQLDataService<LoyaltyCardType> loyaltyCardTypeService
            )
        {
            _loyaltyCardService = loyaltyCardService;
            _loyaltyCardTypeService = loyaltyCardTypeService;
        }
        [Route("api/loyaltycard")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var Cards = _loyaltyCardService.All();

            return Request.CreateResponse(HttpStatusCode.OK, Cards?.Select(x=>new LoyaltyCardModel(x)));
        }
        [HttpGet]
        [Route("api/loyaltycard/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var Card = _loyaltyCardService.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, Card!=null? new LoyaltyCardModel(Card):null);
        }

        [HttpPost]
        [Route("api/loyaltycard")]
        public HttpResponseMessage Post(LoyaltyCardModel model )
        {
            try
            {
                var entity = model.ToEnity();
                entity.CreatedOn = DateTime.UtcNow;
                entity.ModifiedOn = DateTime.UtcNow;
                var CardTypes = _loyaltyCardTypeService.All();
                var CardType = _loyaltyCardTypeService.Find(x => x.SpentThreshold <= entity.TotalSpent)?.FirstOrDefault();
                entity.LoyaltyCardTypeId = CardType.Id;
                entity.StartDate = DateTime.UtcNow;
                if (CardType != null)
                    entity.EndDate = entity.StartDate.Value.AddDays(CardType.Duration);
                else
                    entity.EndDate = entity.StartDate;
                _loyaltyCardService.Insert(entity);
                return Request.CreateResponse(HttpStatusCode.OK, "Card is Created!");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("api/loyaltycard")]
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpDelete]
        [Route("api/loyaltycard")]
        // DELETE: api/LoyaltryCard/5
        public void Delete(int id)
        {
        }
    }
}
