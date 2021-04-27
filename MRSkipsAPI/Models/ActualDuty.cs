using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ActualDuty
    {

        public int ActualDutyId { get; set; }

        [Display(Name = "Actual Route")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }


        //multi Helper
        public virtual ICollection<Helper> Helper { get; set; }  /// <summary>
        /// many--to--many
        /// </summary>

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public DateTime ActualDutyDate { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<VehicleCheckList> VehicleCheckLists { get; set; }
        //public virtual ICollection<Contract> Contracts { get; set; }
        //public virtual ICollection<TripSheet> TripSheets { get; set; }

    }
}