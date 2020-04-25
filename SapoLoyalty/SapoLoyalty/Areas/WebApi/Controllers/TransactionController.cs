using SapoLoyalty.Areas.WebApi.Models;
using SapoLoyalty.DomainObject;
using SapoLoyalty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq.Expressions;
namespace SapoLoyalty.Areas.WebApi.Controllers
{
    public class TransactionController : BaseApiController
    {
        private readonly ISQLDataService<Transaction> _transacitonService;
        private readonly ISQLDataService<Config> _loyaltyConfigService;
        private readonly ILoyaltyCardService _loyaltyCardService;

        public TransactionController(
            ISQLDataService<Transaction> transactionService,
            ISQLDataService<Config> loyaltyConfigService,
            ILoyaltyCardService loyaltyCardService
            )
        {
            _transacitonService = transactionService;
            _loyaltyConfigService = loyaltyConfigService;
            _loyaltyCardService = loyaltyCardService;
        }
        [HttpGet]
        [Route("api/transaction")]
        public JsonMessageModel Get(string access_token = null)
        {
            if (!AuthorizeAccessToken(access_token).success)
                return AuthorizeAccessToken(access_token);
            try
            {
                var trans = _transacitonService.All();
                return new JsonMessageModel() { success = true, statusCode = (int)HttpStatusCode.OK,   data = trans?.Select(x=>new TransactionModel(x))?.ToList() };

            }
            catch (Exception e)
            {
                return ExceptionReturnMessage(e);
            }
        }
        /// <summary>
        /// Xu ly giao dich tich diem
        /// 1) Tao giao dich moi
        /// 2) Kiem tra the tich diem cua khach hang
        /// 3) Kiem tra thong tin cau hinh, lay cau hinh diem dang hoat dong
        /// 4) Tinh diem va ap dung cho khach hang
        /// 5) Kiem tra hang cua the, thay doi hang theo so diem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/transaction")]
        [Route("api/transaction/create")]

        public JsonMessageModel Post(TransactionModel model, string access_token = null)
        {
            if (!AuthorizeAccessToken(access_token).success)
                return AuthorizeAccessToken(access_token);
            try
            {

                if(!ModelState.IsValid)
                    return  new JsonMessageModel { success = false, statusCode = (int)HttpStatusCode.OK, message = "model is valid!" };
                model.CreatedOn = DateTime.UtcNow;
                var trans = model.ToEnity();            
                //curent Config
                var config = _loyaltyConfigService.Find(x=>x.Active)?.FirstOrDefault();
                if (config == null)
                    return  new JsonMessageModel { success = false, statusCode  = (int)HttpStatusCode.OK, message = "Config is not found" };
                //curentCard
                ///Lay config ra, quy doi diem thuong theo hang card, spent adjust ---> pointAdujust
                //spentAdjust-->config(spentAdjust*config)
                var SpentAdjust = trans.SpentAdjust;
                var div = (float)(SpentAdjust) / config.ConfigValue;
                var PointAdjust = Math.Round((float)SpentAdjust / config.ConfigValue, 2);
                trans.PointAdjust = PointAdjust;
                var CardId = trans.LoyaltyCardId;
                var Card = _loyaltyCardService.GetById(CardId);
                if (Card == null)
                    return new JsonMessageModel { success = false, statusCode = (int)HttpStatusCode.OK, message = "Loyalty Card not Found found" };                
                Card.Point += PointAdjust;
                Card.TotalSpent += SpentAdjust;
                //Cap nhat thong tin cho Card
                _loyaltyCardService.Update(Card);
                //Luu giao dich
                _transacitonService.Insert(trans);
                return new JsonMessageModel { success = true, statusCode = (int)HttpStatusCode.OK, message  = $"Trade {trans.Id} created!" };

            }
            catch (Exception e)
            {
                return ExceptionReturnMessage(e);
            }

        }

       
    }
}
