using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Driver
    {
        [Display(Name = "Driver Name")]
        public int DriverId { get; set; }


        [Display(Name = "Driver Name")]
        public String Name { get; set; }

        public String Mobile { get; set; }

        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


        public String AppUserName { get; set; }
        public String AppPassWard { get; set; }



        public virtual ICollection<CdcReceipt> CdcReceipts { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<ActualDuty> ActualDuties { get; set; }
        public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }
        public virtual ICollection<Shift> shift { get; set; }

    }
}