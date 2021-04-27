using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum TripStatusCompactor { Done, Pendding, Cancel }
    public class DriverTripSheet
    {
        public int DriverTripSheetId { get; set; }

        public DateTime TripsDate { get; set; }

        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public String Helpers { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public int? RouteId { get; set; }
        public virtual Route Route { get; set; }


        //contain Customer & Location
        public int ContractId { get; set; }
        public virtual Contract Contracts { get; set; }

        [Display(Name = "D/O Num")]
        public String DoNum { get; set; }

        [Display(Name = "Skip Size")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        //filled by driver after trip
        public int NumberOfSkips { get; set; }

        public string TimeIn { get; set; }

        public int? NoOfTrip { get; set; }
    
        public string wieght { get; set; }

        public string TimeOut { get; set; }

        public string scheduleText { get; set; }
        public TripStatusCompactor Status { get; set; }



    }
}