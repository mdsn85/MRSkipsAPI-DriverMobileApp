using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class TruckType
    {
        public int TruckTypeId { get; set; }

        [Display(Name = "Truck Type")]
        public String Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }



    }



}