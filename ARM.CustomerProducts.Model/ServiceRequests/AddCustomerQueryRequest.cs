using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Shop.Model.ServiceRequests
{
    public class AddCustomerQueryRequest
    {
        public Customer Customer { get; set; }
        public List<int> ProductIds { get; set; }

    }
}
