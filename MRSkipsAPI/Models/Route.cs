using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Route
    {
        public int RouteId { get; set; }

        [Display(Name = "Route")]
        public String Name { get; set; }
        public String Area { get; set; }

        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public bool isActive { get; set; }
        //multi Helper
        public virtual ICollection<Helper> Helper { get; set; }

        //text of many helper
        public String Helpers { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<TripSheet> TripSheets { get; set; }

        public virtual ICollection<ActualDuty> ActualDuties { get; set; }
    }
}