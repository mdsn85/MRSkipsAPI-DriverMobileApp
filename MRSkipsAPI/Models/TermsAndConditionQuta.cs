using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class TermsAndConditionQuta
    {
        public int TermsAndConditionQutaId { get; set; }

        public string Text { get; set; }

        public int QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }
    }
}