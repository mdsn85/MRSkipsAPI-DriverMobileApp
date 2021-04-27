using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Competitor
    {
        public int CompetitorId { get; set; }

        [Display(Name = "Vender / Competitor")]
        public string Name { get; set; }

        public virtual ICollection<Enquery> Enqueries { get; set; }
    }
}