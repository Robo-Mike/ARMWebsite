using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ARM.Shop.DataAccess;
using ARM.Shop.Model;
using ARM.Shop.Model.ServiceRequests;

namespace ARM.Shop.WebService.Services
{
    public class ProductQueryService
    {

        public void Create(AddCustomerQueryRequest request)
        {
            
            var shopContext = new ShopContext("Shop");
            var customer = shopContext.Customers.Add(request.Customer);
            customer.CustomerProductQueries = new List<CustomerProductQuery>();
            foreach (var productId in request.ProductIds)
            {
                customer.CustomerProductQueries.Add(new CustomerProductQuery() { ProductId = productId });
            }

            shopContext.SaveChanges();

            // send email to sales team - in reality would refactor out to a seperate service - more of these settings should probably go in config
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            client.Credentials = new NetworkCredential("username", "password");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("dont-reply@arm.com");
            mailMessage.To.Add("salesteam@arm.com");
            var productNames = shopContext.Products.Where(p => request.ProductIds.Contains(p.Id)).Select(p => p.Name);
            mailMessage.Body =
                $"Customer {customer.FirstName} {customer.LastName} has a price query about Product Ids {string.Join(",", productNames)}";
            mailMessage.Subject = "subject";
            try
            {
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                //dont allow email error to cause issue to user
                //log email error here
            }


        }
    }
}