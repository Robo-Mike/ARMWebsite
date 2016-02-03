using System;
using System.Collections.Generic;
using ARM.Shop.Model;

namespace ARM.Shop.DataAccess
{

    
    public class ShopInitialiser : System.Data.Entity.DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            /*this seeding should be disabled once in production*/
            var products = new List<Product>
            {
            new Product { Name="Superfast RISC Design 1" },
            new Product { Name="Superfast RISC Design 2" },
                new Product { Name="Ultra Low Power RISC x" }
            };

            products.ForEach(s=> context.Products.Add(s));
            context.SaveChanges();
        }
    }
}
