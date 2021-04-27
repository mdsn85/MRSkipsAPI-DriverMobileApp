using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CustomerGroup
    {
        public int CustomerGroupId { get; set; }

        [Display(Name = "Customer Group")]
        public String Name { get; set; }

        public int CustomerGroupCode{ get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}