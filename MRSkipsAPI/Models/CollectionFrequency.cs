using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CollectionFrequency
    {
        public int CollectionFrequencyId { get; set; }


        [Display(Name = "CollectionFrequency")]
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<EnqueryProduct> EnqueryProducts { get; set; }
    }
}