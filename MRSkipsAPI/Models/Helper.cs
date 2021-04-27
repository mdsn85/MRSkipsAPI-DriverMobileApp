using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Helper
    { 
        [Display(Name = "Helper Name")]
        public int HelperId { get; set; }

        [Display(Name = "Helper Name")]
        public String Name { get; set; }

        public String Mobile { get; set; }


        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Route> Route { get; set; }//multi aginst
        public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }//multi aginst
        public virtual ICollection<ActualDuty> ActualDuty { get; set; }//multi aginst
        public virtual ICollection<TripSheet> TripSheet { get; set; }//multi aginst
                                                                     //public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }

        [Display(Name = "Shift")]
        public virtual ICollection<ShiftHelperLink> ShiftHelperLinks { get; set; }
    }
}