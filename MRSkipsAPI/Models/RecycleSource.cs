using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class RecycleSource
    {
        public int RecycleSourceId { get; set; }
        public string Name { get; set; }

        //multi Helper
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Enquery> Enqueries { get; set; }
    }
}