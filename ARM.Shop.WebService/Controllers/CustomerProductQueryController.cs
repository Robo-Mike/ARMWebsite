using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using ARM.Shop.Model;
using ARM.Shop.DataAccess;
using ARM.Shop.Model.ServiceRequests;
using ARM.Shop.WebService.Services;

namespace ARM.Shop.WebService.Controllers
{
    public class CustomerProductQueryController : ApiController
    {


        // POST: api/CustomerProductQuery
        public void Post([FromBody]AddCustomerQueryRequest request)
        {
           new ProductQueryService().Create(request);
            
        }

      
    }
}
