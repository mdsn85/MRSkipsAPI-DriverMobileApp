using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class NatureOfBusiness
    {
        public int NatureOfBusinessId { get; set; }
        [Display(Name = "Nature Of Business")]
        public String Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Enquery> Enqueries { get; set; }
        //public virtual ICollection<Customer> Customers { get; set; }

    }
}