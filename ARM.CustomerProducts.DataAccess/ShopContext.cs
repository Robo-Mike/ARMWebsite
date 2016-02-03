using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARM.Shop.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ARM.Shop.DataAccess
{
    public class ShopContext:DbContext
    {

        public ShopContext(string connectionStringName) : base(connectionStringName)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProductQuery> CustomerProductQueries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

          

        }
    }

    

}
