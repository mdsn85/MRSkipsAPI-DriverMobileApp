using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class RequestApproval
    {
        public int RequestApprovalId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }

        public int RequestApprovalTypeId { get; set; }
        public virtual RequestApprovalType RequestApprovalType { get; set; }

        public int? QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }

        public int? ContractId{get;set;}
        public virtual Contract Contract { get; set; }

        public string details { get; set; }


        [Display(Name = "Username")]
        public string UserName  { get; set; }

        [Display(Name = "Sales Manager")]
        public bool SalesManager { get; set; }
        [Display(Name = "BDM")]
        public bool BDM { get; set; }
        [Display(Name = "Sr.C.M Approval")]
        public bool CoordinatorFull { get; set; }
        [Display(Name = "Mngt. Approval")]
        public bool CoordinatorPartial { get; set; }
        [Display(Name = "CEO")]
        public bool CEO { get; set; }

        public bool? IsRejected { get; set; }

        public string SalesManagerRemarks { get; set; }
        public string BDMRemarks { get; set; }
        public string CoordinatorFullRemarks { get; set; }
        public string CoordinatorPartialRemarks { get; set; }
        public string CEORemarks { get; set; }


        public string SalesManagerDate { get; set; }


        public string BDMDate { get; set; }


        public string CoordinatorFullDate { get; set; }


        public string CoordinatorPartialDate { get; set; }


        public string CEODate { get; set; }
    }
}