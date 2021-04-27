using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class LpoStatus
    {
        public int LpoStatusId { get; set; }

        [Display(Name = "Lpo Status")]
        public String Name { get; set; }

        public virtual ICollection<LPO> LPOs { get; set; }
    }
}