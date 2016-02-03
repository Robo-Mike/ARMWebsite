using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ARM.Shop.DataAccess;
using ARM.Shop.Model;

namespace ARM.Shop.WebService.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IEnumerable<Product> Get()
        {
            var shopContext = new ShopContext("Shop");
            var products = shopContext.Products;
            return products;
        }
        


        
    }
}
