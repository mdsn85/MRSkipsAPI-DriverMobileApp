using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class SkipType1
    {

        public int SkipType1Id { get; set; }

        [Display(Name = "Skip Type")]
        public String Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<Enquery> Enqueries { get; set; }

    }
}