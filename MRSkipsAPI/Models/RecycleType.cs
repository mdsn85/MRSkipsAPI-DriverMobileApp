using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class RecycleType
    {
        public int RecycleTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<Enquery> Enqueries { get; set; }
    }
}