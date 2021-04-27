using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class InvoiceDeliveryLocation
    {
        public int InvoiceDeliveryLocationId { get; set; }
        //SiteOffice ,Office
        [Display(Name = "Invoice Delivery Location")]
        public string Name { get; set; }


        public virtual ICollection<KYC> KYC { get; set; }

    }
}