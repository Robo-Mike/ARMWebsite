using System;
using System.Collections.Generic;
using ARM.Shop.Model;

namespace ARM.Shop.Model
{


    public class CustomerProductQuery
    {
        
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
