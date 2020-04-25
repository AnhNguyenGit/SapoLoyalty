using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SapoLoyalty.Areas.WebApi.Controllers;
using SapoLoyalty.DomainObject;
using SapoLoyalty.Services;
using SapoLoyalty.Areas.WebApi.Models;
using System.Configuration;
using System.Collections.Specialized;

namespace SapoLoyalty.Test
{
  [TestFixture]
  public class TransactionControllerTest
    {
        TransactionController controller = null;
        ISQLDataService<Transaction> _transactionService;
        ISQLDataService<Config> _configService;
        ILoyaltyCardService _cardService;
        Mock<ISQLDataService<Config>> configMock = new Mock<ISQLDataService<Config>>();
        Mock<ISQLDataService<Transaction>> transactionMock = new Mock<ISQLDataService<Transaction>>();
        Mock<ILoyaltyCardService> cardMock = new Mock<ILoyaltyCardService>();
        string tokentest = "Osr1F6FzEHHRkZTR1Tn6BL6jeWH4kN3X";

        [SetUp]
        public void SetUp()
        {
            
            _transactionService = transactionMock.Object;
            _configService = configMock.Object;
            _cardService = cardMock.Object;
            var sampledate = LoyaltySampleDataTest.Transactions;
            transactionMock.Setup(x => x.All())
                 .Returns(LoyaltySampleDataTest.Transactions);
            controller = new TransactionController(_transactionService, _configService, _cardService);
        }

        [Test]
        public void Request_Should_Access_Token_IsRequire()
        {
            var res = controller.Get();
            var success = res.success;
            Assert.IsFalse(success);
            res = controller.Get(access_token: "dafasdfsadfdsa");
            success = res.success;
            Assert.IsFalse(success);
            Assert.AreSame(res.message, "Acces_token InValid");
        }
        [Test]
        public void Get_Method_Should_Return_All_Data()
        {
          
          var res =   controller.Get(access_token:tokentest);
          var trans = res.data as List<TransactionModel>;
          var trancount = trans.Count;
          var expect = LoyaltySampleDataTest.Transactions.Count;
           
          Assert.AreEqual(trans.Count, LoyaltySampleDataTest.Transactions.Count);
        }
        [Test]
        public void Post_Method_Success_False_When_Config_Is_Null()
        {
            configMock.Setup(x => x.Find(y => y.Active))
                .Returns(new List<Config>());           
            var modelTest = new TransactionModel();
            var res = controller.Post(modelTest, access_token:tokentest);            
            var status = res.success;
            Assert.IsFalse(status);
            Assert.AreEqual(res.statusCode, 200);
           
        }
        [Test]
        public void Post_Method_Success_True_Insert_NewData_ToDB()
        {
            var modelTest = new TransactionModel() {
                LoyaltyCardId = 1,
                PointAdjust = 5000000,
                CreatedOn = DateTime.UtcNow
            };            
            configMock.Setup(x => x.Find(y => y.Active))
               .Returns(LoyaltySampleDataTest.Configs.Where(x=>x.Active).ToList());
            cardMock.Setup(x => x.GetById(modelTest.LoyaltyCardId))
                .Returns(LoyaltySampleDataTest.LoyaltyCards.FirstOrDefault(x => x.Id == modelTest.LoyaltyCardId));
            var res = controller.Post(modelTest,access_token:tokentest);
            Assert.AreEqual(res.statusCode, 200);
            Assert.IsTrue(res.success);
            
        }
       
    }
}
