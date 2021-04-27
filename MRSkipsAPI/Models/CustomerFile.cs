using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CustomerFile
    {


        public int CustomerFileId { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }

        [Display(Name = "Valid Until")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy }")]
        public DateTime ValidUntil { get; set; }

        public bool IsActive { get; set; }

        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int? KYCId { get; set; }
        public virtual KYC KYC { get; set; }

        public int? ContractId { get; set; }
        public virtual Contract Contract { get; set; }


        public virtual Quotation Quotation { get; set; }
        public int? QuotationId { get; set; }

        public int? LPOId { get; set; }
        public virtual LPO lpo { get; set; }

        public int CustomerFileTypeId { get; set; }
        public virtual CustomerFileType CustomerFileTypes { get; set; }


    }
}