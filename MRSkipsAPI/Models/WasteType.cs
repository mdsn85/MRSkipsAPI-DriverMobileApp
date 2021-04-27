using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class WasteType
    {
        public int WasteTypeId { get; set; }

        [Display(Name = "Waste Type")]
        public String  Name { get; set; }


        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Enquery> Enqueries { get; set; }
        public virtual ICollection<EnqueryProduct> EnqueryProducts { get; set; }

    }
}