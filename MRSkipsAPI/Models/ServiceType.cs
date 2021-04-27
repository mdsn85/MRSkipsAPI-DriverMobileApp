using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{

    // this for call
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }

        [Display(Name = "Service Type")]
        public String Name { get; set; }

        public virtual ICollection<CallBased> CallBaseds { get; set; }

        public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }
    }

}