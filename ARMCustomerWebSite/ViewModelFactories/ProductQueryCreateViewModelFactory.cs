using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARMCustomerWebSite.ClientServices;
using ARMCustomerWebSite.Models;

namespace ARMCustomerWebSite.ViewModelFactories
{
    public interface IProductQueryCreateViewModelFactory
    {
        ProductQueryCreateViewModel Create();
        ProductQueryCreateViewModel CreateWithExistingModel(ProductQueryCreateViewModel model);
    }

    public class ProductQueryCreateViewModelFactory : IProductQueryCreateViewModelFactory
    {

        public  ProductQueryCreateViewModel Create()
        {
            
            var model = new ProductQueryCreateViewModel();
            return CreateWithExistingModel(model);
        }

        public ProductQueryCreateViewModel CreateWithExistingModel(ProductQueryCreateViewModel model)
        {
            //Note this should come from a look up data service with iso id   
            var countries = new Dictionary<int, string>();
            countries.Add(1, "UK");
            countries.Add(2, "United States");
            countries.Add(3, "Ireland");
            var products = new ProductService().GetProducts();
            model.Products = new SelectList((IEnumerable) products, "Id", "Name");
            model.Countries = new SelectList(countries, "key", "value");
            return model;
        }




    }
}