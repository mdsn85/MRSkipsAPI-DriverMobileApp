using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class LPO
    {
       public int LPOId { get; set; }

        [Display(Name = "LPO Code")]
        public int LPONo { get; set; }

        [Display(Name = "LPO Cust. Ref No")]
        public string LPORefNo { get; set; }

        [Display(Name = "Contract")]
        public int? ContractId { get; set; }
        public virtual Contract Contracts { get; set; }

        [Display(Name = "Customer")]
        public int? CustomerId { get; set; } //(select from system)
        public virtual Customer Customer { get; set; }

        [Required]
        [Display(Name = "LPO Type")]
        public int LpoTypeId { get; set; }
        public virtual LpoType LpoTypes { get; set; }

        [Display(Name = "Lpo Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//@"{0:dd\/MM\/yyyy}
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]

        public DateTime? LpoDate { get; set; }


        [Display(Name = "Skip Size")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        [Display(Name = "No. Of Skips")]
        public int NoOfSkips { get; set; }

        [Display(Name = "TO BE ATTACHED IN THE INVOICE? ")]
        public bool AttachedInInvoice { get; set; }

        [Display(Name = "LPO Contact Person")]
        public string  LPOContactPerson { get; set; }

        [Display(Name = "LPO Contact Number")]
        public string LPOContactNumber { get; set; }

        [Display(Name = "LPO Contact email ID")]
        [EmailAddress]
        public string LPOContactEmailID { get; set; }

        public String Remarks { get; set; }

        [Display(Name = "Service Requested QTY")]
        public int? ServiceRequestedQuantity { get; set; }//(Quantity Base)

        [Display(Name = "Serviced Actual Qty")]
        public int ServicedActualQty { get; set; }//(Quantity Base)

        [Display(Name = "Balance Qty")]
        public int BalanceQty { get; set; }//(Quantity Base)

        [Display(Name = "Balance Qty On Availed Trip")]
        public int BalanceQtyOnAvailedTrip { get; set; }//(Quantity Base)
        
        [Display(Name = "Start Date")]
        //[DataType(DataType.Date)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]

        public DateTime? LpoStartDate { get; set; }// Date(Period Base)

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//@"{0:dd\/MM\/yyyy}
        public DateTime? LpoEndDate { get; set; }//(Period Base)

        [Display(Name = "terminated Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//@"{0:dd\/MM\/yyyy}//ExtentionLPo No  { get; set; }//(Period Base)
        public DateTime? TerminatedDate { get; set; }

        [Display(Name = "Extended LPOID")]
        public int? ExtendedLPOID { get; set; }

        [Display(Name = "Extended LPO Number")]
        public int? ExtendedLPONo { get; set; }

        [Display(Name = "Extended LPO Ref")]
        public String ExtendedLPORefNo { get; set; }
        
        [Display(Name = "LPO Status")]
        public int LpoStatusId { get; set; }//(active, expired, terminated, suspend)
        public virtual LpoStatus LpoStatuses{ get; set; }

        [Display(Name = "Qty Consumed")]
        public int? QtyConsumed { get; set; }

        public String SuspendReason { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//@"{0:dd\/MM\/yyyy}
        public DateTime? SuspendDate { get; set; }


        public String TerminatedReason { get; set; }

        public String FileName { get; set; }
        public String FilePath { get; set; }



        public bool IsActive { get; set; } //easy access

 
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<LpoSuspend> LpoSuspends { get; set; }

        public virtual ICollection<CustomerFile> CustomerFiles { get; set; }


        public virtual ICollection<Lpofile> Lpofiles { get; set; }

    }
}