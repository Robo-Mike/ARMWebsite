using ARM.Shop.DataAccess;
using ARM.Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARMCustomerWebSite.ClientServices;

namespace ARMCustomerWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new ProductService();
            var products = service.GetProducts();

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