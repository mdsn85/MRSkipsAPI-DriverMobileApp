using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class LpoType
    {
        public int LpoTypeId { get; set; }
        [Display(Name = "Lpo Type")]
        public String Name { get; set; }

        public virtual ICollection<LPO> LPOs { get; set; }
    }
}