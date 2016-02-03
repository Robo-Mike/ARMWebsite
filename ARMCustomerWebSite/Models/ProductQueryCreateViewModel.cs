using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARMCustomerWebSite.Models
{
    public class ProductQueryCreateViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string EmailAddress { get; set; }
        [DisplayName("Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }
        
        [Required]
        public string City { get; set; }
        [Required]
        public string Postcode { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [DisplayName("Country")]
        [Required]
        public int SelectedCountryId { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber { get; set; } 

        public IEnumerable<SelectListItem> Products { get; set; }

        [DisplayName("Please select the products you wish to price query")]
        [Required (ErrorMessage="Please select at least one product")]
        public int[] SelectedProductIds { get; set; }

    }
}