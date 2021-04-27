using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Vehicle
    {
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Plate No")]
        public String PlateNo { get; set; }


       // [Display(Name = "Model")]
       // public String TruckType { get; set; }

        [Display(Name = "Vehicle Maker")]
        public int? VehicleMakerId { get; set; }
        public virtual VehicleMaker VehicleMaker { get; set; }

        [Display(Name = "Vehicle type")]
        public int? TruckTypeId { get; set; }
        public virtual TruckType TruckType { get; set; }

        public String Description { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<ActualDuty> ActualDuties { get; set; }
        public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }
        public virtual ICollection<Shift> shift { get; set; }
    }
}