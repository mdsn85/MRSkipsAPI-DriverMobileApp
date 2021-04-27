using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        [Display(Name = "Area")]
        public String Name { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Enquery> Enqueries { get; set; }

        public virtual ICollection<LocationMaster> LocationMasters { get; set; }
    }
}