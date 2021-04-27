using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class VehicleCheckList
    {
        public int VehicleCheckListId { get; set; }
        public String Reason { get; set; }

        public bool LIGHTSINDICATORS { get; set; }
        public bool ENGINEOILLEVEL { get; set; }
        public bool HYDRAULICOILLEVEL { get; set; }
        public bool REDIATORCOOLENTLEVEL { get; set; }
        public bool WIPERMIRROR { get; set; }
        public bool HYDRAULICFUNCTION { get; set; }
        public bool ALLTYRES { get; set; }
        public bool VEHICLECLEANLINESS { get; set; }
        public bool PPEFIRSTAID { get; set; }
        public bool UNIFORM { get; set; }
        public bool WARNINGTRIANGLE { get; set; }
        public bool TARPAULINE { get; set; }
        public bool BODYDAMAGE { get; set; }
        public bool SEATBELTAC { get; set; }
        public bool TOOLS { get; set; }
        public bool VEHICLEPAPERS { get; set; }
        public bool FIREEXTINGUSHER { get; set; }

        public DateTime CheckDate { get; set; }

        public int TripSheetId { get; set; }
        public virtual TripSheet TripSheet { get; set; }

        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }



        [Display(Name = "Vehicle Plate")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public Boolean VehicleReady()
        {
            return this.ENGINEOILLEVEL && this.HYDRAULICOILLEVEL && this.REDIATORCOOLENTLEVEL && HYDRAULICFUNCTION && this.SEATBELTAC && 
                this.TOOLS && this.VEHICLEPAPERS && this.FIREEXTINGUSHER;
        }

    }
}