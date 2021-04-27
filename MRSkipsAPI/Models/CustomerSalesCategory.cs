using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CustomerSalesCategory
    {

        public int CustomerSalesCategoryId { get; set; }

        [Display(Name = "Customer Sales Category")]
        public String  Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}