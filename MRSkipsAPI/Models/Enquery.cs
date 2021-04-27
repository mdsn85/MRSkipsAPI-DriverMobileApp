using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    // public enum EnqueryStatusList { Open /*when create*/, Quotation_FollowUp /*when create Qutation*/,Hot, Out_Of_Scope ,Success, Re_approach }
    public enum EnqueryStatusList { Targeted /*when create*/, Active /*when create Qutation*/, Hot, Closed, FutureLead, Lost }
    public class Enquery
    {
        public int EnqueryId { get; set; }

        public int Sequense { get; set; }

        [Display(Name = "Opportunity Code")]
        public String Code { get; set; }

        [Display(Name = "Opportunity Status")]
        public EnqueryStatusList? EnqueryStatus { get; set; }

        [Display(Name = "Opportunity Status")]
        public int? EnqueryStatusId { get; set; } //(select from system)
        public virtual EnqueryStatus EnqueryStatus1 { get; set; }

        [Display(Name = "Reason Status")]
        public String StatusReason { get; set; }

        [Display(Name = "Next Followup Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NextDateFollowup { get; set; }

        [Display(Name = "Is New Customer")]
        public bool IsNewCustomer { get; set; }

        [Display(Name = "Notice Period (Vendor)")]
        public int NoticePeriod { get; set; }

        [Display(Name = "Expected Closure Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpectedClosureDate { get; set; }

        /// <summary>
        /// Select customer get details from customer master  (contact /salesman)
        /// </summary>
        /// [Required(AllowEmptyStrings = true)]
        [Display(Name = "Select Customer")]
        public int? CustomerId { get; set; } //(select from system)
        public virtual Customer Customer { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Customer")]
        public String CustomerName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Contact Person")]
        public String ContactPerson { get; set; }

        [Display(Name = "Designation")]
        public String Designation { get; set; }
 
        [Required(ErrorMessage = "You must provide a phone number in formate xx-xxxxxxx")]
        [Display(Name = "LandLine Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0x-xxxxxxx")]
        public string TelephoneNo { get; set; }


        [Required(ErrorMessage = "You must provide a Mobile number in formate xxx-xxxxxxx")]
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0xx-xxxxxxx")]
        public String MobileNo { get; set; }

        [Display(Name = "Fax No")]
        public String FaxNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String EmailId { get; set; }
        [Display(Name = "How Did You Hear About Us?")]
        public String HowUCome { get; set; }

        [Display(Name = "Recycling Remarks")]
        public String RecyclingRemarks { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = " Project Name")]
        public String ProjectName { get; set; }


        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Nature Of Business")]
        public int? NatureOfBusinessId { get; set; }//(active, expired, terminated, suspend)
        [Display(Name = "Nature Of Business")]
        public virtual NatureOfBusiness NatureOfBusinesses { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Waste Type")]
        public int? WasteTypeId { get; set; }
        public virtual WasteType WasteTypes { get; set; }

        [Display(Name = "Vender / Competitor")]
        public int CompetitorId { get; set; }
        public virtual Competitor Competitor { get;set;}

        ////
        [Display(Name = "Last Meeting Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastMeeting { get; set; }

        [Display(Name = "schedule Next Meeting")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NextMeeting { get; set; }

        /////////////

        [Display(Name = "Is New Location")]
        public bool IsNewLocation { get; set; }

        [Display(Name = "Area")]
        public int? AreaId { get; set; } //(select from system)
        public virtual Area Area { get; set; }

        [Display(Name = "Location")]
        public String Location { get; set; }

        [Display(Name = "Sales Person")]
        public int SalesManId { get; set; } //(select from system)
        public virtual SalesMan SalesMan { get; set; }

        [Display(Name = "Payment Term (Vendor)")]
        public int? PaymentTermId { get; set; } //(select from system)
        public virtual PaymentTerm PaymentTerm { get; set; }
        // comon
        [Display(Name = "Comments")]
        public String Description { get; set; }

        //collect location from contract of selected customers

        [Display(Name = "Recycables Available ?")]
        public bool IsRecycables { get; set; }
        public bool FOC { get; set; }
        public virtual ICollection<RecycleSource> RecycleSources { get; set; }

        public virtual ICollection<RecycleType> RecycleTypes { get; set; }


        [Display(Name = "Created Date")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Created By")]
        public String UserCreate { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Last Updated By")]
        public String UserLastUpdate { get; set; }

        [Display(Name = "Last Status Date")]
        public DateTime? LastStatusDate { get; set; }

        [Display(Name = "Status Changed By")]
        public String UserLastStatus { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<EnqueryProduct> EnqueryProducts { get; set; }



        [Display(Name = "Stamp Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? StampDate { get; set; }
    }
}