using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Lpofile
    {
        public int LpofileId { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }


        public DateTime? ValidUntil { get; set; }

        public virtual LPO LPO { get; set; }
        public int? LPOId { get; set; }
    }
}