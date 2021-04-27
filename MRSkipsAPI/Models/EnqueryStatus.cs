using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class EnqueryStatus
    {
        public int EnqueryStatusId { get; set; }

        [Display(Name = "Contract Status")]
        public String Name { get; set; }


        public virtual ICollection<Enquery> Enqueries { get; set; }
    }
}