using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.ViewModels
{
    public class VehicleCheckListVM
    {
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

        public string token { get; set; }
        public float StartKM { get; set; }
    }
}