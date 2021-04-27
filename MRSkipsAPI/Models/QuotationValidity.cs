using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class QuotationValidity
    {
        public int QuotationValidityId { get; set; }

        [Display(Name = "Validity")]
        public String Name { get; set; }


        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}