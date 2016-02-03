using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Shop.Model
{
    /// <summary>
    /// 
    /// Given the stated requirements I think this is OK but a proper registration process were used for the customer (e.g. email verification)
    /// db  would have to be added to prevent duplicate email address records
    /// </summary>
    public class Customer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public int CountryId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<CustomerProductQuery> CustomerProductQueries { get; set; }
    }
}
