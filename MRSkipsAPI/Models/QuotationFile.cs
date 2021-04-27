using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class QuotationFile
    {

        public int QuotationFileId { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }


       // public DateTime ValidUntil { get; set; }

        public virtual Quotation Quotation { get; set; }
        public int? QuotationId { get; set; }
    }
}