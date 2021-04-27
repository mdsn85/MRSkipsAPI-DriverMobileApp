using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    
    public class TripSheet
    {
        public int TripSheetId { get; set; }

        [Display(Name = "For Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime TripsDate { get; set; }

        [Display(Name = "Route")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public String Helpers { get; set; }
        public virtual ICollection<Helper> Helper { get; set; }

        [Display(Name = "Vehicle Plate")]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ActualDutyDate { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<VehicleCheckList> VehicleCheckLists { get; set; }

        public virtual ICollection<TripSheetDaetails> TripSheetDaetail { get; set; }
    }
}