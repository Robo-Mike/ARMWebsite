using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARM.Shop.Model;
using ARM.Shop.Model.ServiceRequests;
using ARMCustomerWebSite.ClientServices;
using ARMCustomerWebSite.Models;
using ARMCustomerWebSite.ViewModelFactories;

namespace ARMCustomerWebSite.Controllers
{
    public class ProductQueryController : Controller
    {
        private IProductQueryCreateViewModelFactory _productQueryCreateViewModelFactory;
        public ProductQueryController()
        {
                _productQueryCreateViewModelFactory = new ProductQueryCreateViewModelFactory();
        }
        /// <summary>
        /// Constructor for testing - in practice would use IOC ran out of time
        /// </summary>
        /// <param name="productQueryCreateViewModelFactory"></param>
        public ProductQueryController(IProductQueryCreateViewModelFactory productQueryCreateViewModelFactory)
        {
            _productQueryCreateViewModelFactory = productQueryCreateViewModelFactory;
        }




        /// <summary>
        /// Uses POST GET REDIRECT TO AVOID DUPLICATES
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var model = _productQueryCreateViewModelFactory.Create();
            return View("Create",model);
        }

       

        [HttpPost]
        public ActionResult Create(ProductQueryCreateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model = _productQueryCreateViewModelFactory.CreateWithExistingModel(model);
                return View(model);
            }
            //call service - would wrap this in seperate testable class if more time
            var customer = new Customer() {AddressLine1 = model.AddressLine1, City = model.City, CountryId = model.SelectedCountryId, DateCreated = DateTime.Now,EmailAddress = model.EmailAddress,FirstName = model.FirstName, LastName = model.LastName,Postcode = model.Postcode};
            var query= new AddCustomerQueryRequest () {Customer = customer, ProductIds = model.SelectedProductIds.ToList()};
            
            new ProductService().CreateProductQuery(query);
            return RedirectToAction("CreateConfirm");
        }

        public ActionResult CreateConfirm()
        {
            return View();
        }


    }
}