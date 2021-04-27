using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class SkipType
    {
        public int SkipTypeId { get; set; }


        [Display(Name = "Skip Type 1")]
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}