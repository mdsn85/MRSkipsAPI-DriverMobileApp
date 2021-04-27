using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Shift
    {


        public int ShiftId { get; set; }

        [Display(Name = "Employee Name")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Display(Name = "Driver Name")]
        public int? DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        [Display(Name = "Vehicle")]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }


        [Display(Name = "Helper")]
        public virtual ICollection<ShiftHelperLink> ShiftHelperLinks { get; set; }

        public int? ActualDutyId { get; set; }
        public virtual ActualDuty ActualDuty { get; set; }

        public DateTime StartShift { get; set; }

        public DateTime? EndShift { get; set; }

        public float? StartKM { get; set; }
        public float? EndKM { get; set; }

        public int? TripSheetId { get; set; }
        public virtual TripSheet TripSheet { get; set; }

        public virtual ICollection<FuelRecipt> FuelRecipts { get; set; }

        public virtual ICollection<Dumb> Dumbs { get; set; }

    }
}