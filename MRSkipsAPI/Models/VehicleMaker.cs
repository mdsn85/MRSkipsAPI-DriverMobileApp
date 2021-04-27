using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class VehicleMaker
    {

        public int VehicleMakerId { get; set; }

        public String Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}