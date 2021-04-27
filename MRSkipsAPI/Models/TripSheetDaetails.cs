using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum TripStatus { pending /*(before allocation)*/, allocated, complete, drop /*(failed they can re-allocate)*/,canceled }
    public class TripSheetDaetails
    {
        public int TripSheetDaetailsId { get; set; }

        //public int TripSheetId { get; set; }
        //public virtual TripSheet TripSheets { get; set; }
        [Display(Name = "Trips Date")]

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime TripsDate { get; set; }

        //contain Customer & Location
        public int ContractId { get; set; }
        public virtual Contract Contracts { get; set; }


        [Display(Name = "D/O Num")]
        public String DoNum { get; set; }

        [Display(Name = "Skip Serial Number")]
        public String SkipSerialNumber { get; set; }


        [Display(Name = "Skip Size")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        //Planed trip
        public int NumberOfSkips { get; set; }

        //filled by driver after trip
        public int? NumberOfSkipscollected { get; set; }


        public String Timein { get; set; }

        public String Timeout { get; set; }

        public String Weight { get; set; }

        public String Remarks { get; set; }

        public TripStatus Status { get; set; }

        [Display(Name = "Route")]
        public int? RouteId { get; set; }
        public virtual Route Route { get; set; }


        [Display(Name = "Driver")]
        public int? DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public virtual ICollection<Helper> Helper { get; set; }
        public String Helpers { get; set; }

        [Display(Name = "Vehicle Plate")]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }


        public int? ServiceTypeId { get; set; }
        public virtual ServiceType ServiceTypes { get; set; }

        public int? CallBasedId { get; set; }
        public virtual CallBased CallBased { get; set; }

        public virtual ICollection<TripSheetDeatails_skip> TripSheetDeatails_skips { get; set; }

        public int? TripSheetId { get; set; }
        public virtual TripSheet TripSheet { get; set; }

    }
}