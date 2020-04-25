using Microsoft.VisualStudio.TestTools.UnitTesting;
using SapoLoyalty.Areas.WebApi.Controllers;
using SapoLoyalty.DomainObject;
using SapoLoyalty.Services;
using Moq;
using System.Collections.Generic;
using SapoLoyalty.Areas.WebApi.Models;
using System.Linq;
namespace SapoLoyaltyTest
{
   [TestClass]
   
   public class TransactionControllerTest
    {
       
            Mock<ISQLDataService<Transaction>> TransMock = new Mock<ISQLDataService<Transaction>>();
            Mock<ISQLDataService<Config>> ConfigMock = new Mock<ISQLDataService<Config>>();
            Mock<ILoyaltyCardService> CardMock = new Mock<ILoyaltyCardService>();
        public  TransactionControllerTest()
        {

        }
        [TestMethod]
        public void Test_GetAll_Transaction()
        {

            var _transactionService = TransMock.Object;
            var _configService = ConfigMock.Object;
            var _cardService = CardMock.Object;

            //Setup Data
            TransMock.Setup(x => x.All())
                .Returns(LoyaltySampletTestData.Transactions);
            CardMock.Setup(x => x.All())
                .Returns(LoyaltySampletTestData.Cards);

            var transactionController = new TransactionController(_transactionService,_configService,_cardService);
            var trans = transactionController.Get();
            var Count = trans.data as List<TransactionModel>;
            var ModelList = LoyaltySampletTestData.Transactions.Select(x => new TransactionModel(x)).ToList();
            var DataList = trans.data as List<TransactionModel>;
            Assert.AreEqual(LoyaltySampletTestData.Transactions.Select(x=>new TransactionModel(x)).ToList().Count, (trans.data as List<TransactionModel>).Count);
            
        }
        [TestMethod]
        public void Test_Create_Transaction()
        {

        }
        
    }
}
