using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{

    public enum TripStatus_skip { Complete /*(before allocation)*/, visit_charge, visit_free, drop /*(failed they can re-allocate)*/, No_Action, unsign }


    public class TripSheetDeatails_skip
    {
        public int TripSheetDeatails_skipId { get; set; }
        public int TripSheetDaetailsId { get; set; }
        public virtual TripSheetDaetails TripSheetDaetails { get; set; }
        [Display(Name = "Skip Size")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
        [Display(Name = "D/O Num")]
        public String DoNum { get; set; }
        [Display(Name = "Skip Serial Number")]
        public String SkipSerialNumber { get; set; }
        [Display(Name = "Skip Serial Number")]
        public String SkipSerialNumber2 { get; set; }
        public float Weight { get; set; }
        public String Remarks { get; set; }
        // i add ?
        public TripStatus_skip? Status { get; set; }
        public String ReasonImg { get; set; }
        public String SignateImg { get; set; }
        public int? DumbId { get; set; }
        public virtual Dumb Dumb { get; set; }
        public bool isYard { get; set; }
        public float? ServiceCharges { get; set; }
        public String Timein { get; set; }
        public String Timeout { get; set; }

        public int? DumpLocationId { get; set; }
        public virtual DumpLocation DumpLocation { get; set; }

        public string WasteTypex { get; set; }
        public String Reason { get; set; }
        public String SignName { get; set; }
        public String SignMobile { get; set; }
        public String SignTel { get; set; }
        public String UserId { get; set; }

    }
}