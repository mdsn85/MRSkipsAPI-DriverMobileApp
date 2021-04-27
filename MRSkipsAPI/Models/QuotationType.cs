using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class QuotationType
    {
        public int QuotationTypeId { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}