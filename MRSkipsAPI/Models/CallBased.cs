using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum CallStatus { pending /*(before allocation)*/, allocated, drop /*(failed they can re-allocate)*/, canceled,completed }
    public class CallBased
    {
        public int CallBasedId { get; set; }

        [Display(Name = "Trip Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Colection_Date { get; set; }
        [Display(Name = "No. Skip")]
        public int NumOfSkips { get; set; }
        [Display(Name = "Waste Type")]
        public String WasteType { get; set; }
        [Display(Name = "Caller Name")]
        public string CallerName { get; set; }
        [Display(Name = "Phone")]
        public string CallerNymber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        public bool isSRF{ get; set; }
        [Display(Name = "Follow Up No.")]
        public int? FollowUpNo { get; set; }
        [Display(Name = "Follow Up Remarks")]
        public string FollowUpRemarks { get; set; }
        [Display(Name = "Manager Approval")]
        public bool ManagerApproval { get; set; }

        [Display(Name = "Account Approval")]
        public bool AccountApproval { get; set; }


        [Display(Name = "Call Status")]
        public CallStatus Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceTypes { get; set; }
        public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }
    }
}