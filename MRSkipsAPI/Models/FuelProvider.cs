using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class FuelProvider
    {
        public int FuelProviderId { get; set; }
        [Display(Name = "Fuel Station")]
        [StringLength(20)]
        public String Name { get; set; }
        public float Rate { get; set; }
    }
}