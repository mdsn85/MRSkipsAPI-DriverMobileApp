using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class QuotationStatusAudit1
    {
        public int id { get; set; }
        public int QuotationStatusId { get; set; }

        public String UserLastStatus { get; set; }

        [Display(Name = "Last Status Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy }", ApplyFormatInEditMode = true)]
        public DateTime? LastStatusDate { get; set; }
        public String StatusReason { get; set; }

        public int QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }

    }
}