using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class LocationMaster
    {

        public int LocationMasterId { get; set; }

        [Display(Name = "Location")]
        public String Name { get; set; }

        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}