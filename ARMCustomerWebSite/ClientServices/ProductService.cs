using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ARM.Shop.Model;
using ARM.Shop.Model.ServiceRequests;

namespace ARMCustomerWebSite.ClientServices
{
    public class ProductService
    {
       
       
        public void AddCommonSettings(HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["StoreWebServiceBaseAddress"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var client = new HttpClient())
            {
                AddCommonSettings(client);
                HttpResponseMessage response = client.GetAsync("api/products").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
                throw new HttpRequestException("Problem calling webapi service to get products");
            }
            
            
        }

        public void CreateProductQuery(AddCustomerQueryRequest query)
        {
            using (var client = new HttpClient())
            {
                AddCommonSettings(client);
                HttpResponseMessage response = client.PostAsJsonAsync("api/customerproductquery", query).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Problem calling webapi service to create product query");

                }

            }

            

        }


    }




}