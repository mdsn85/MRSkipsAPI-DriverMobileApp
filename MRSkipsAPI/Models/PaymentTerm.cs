using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class PaymentTerm
    {
        public int PaymentTermId { get; set; }

        [Display(Name = "Payment Term")]
        public String Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Enquery> Enqueries { get; set; }
    }
}