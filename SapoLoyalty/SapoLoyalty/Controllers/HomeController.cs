using Autofac;
using SapoLoyalty.DomainObject;
using SapoLoyalty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SapoLoyalty.Controllers
{
    public class HomeController : Controller
    {
        private ISQLDataService<LoyaltyCard> _sqlService;
        public HomeController(ISQLDataService<LoyaltyCard> sqlService)
        {

            _sqlService = sqlService;
          
        }

       
        public ActionResult Index()
        {
           //var s=  _loyaltyService.All();
            var data = _sqlService.All();
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}