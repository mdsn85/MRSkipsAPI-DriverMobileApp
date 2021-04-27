using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class DumpLocation
    {
        public int DumpLocationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TripSheetDeatails_skip> TripSheetDeatails_skips { get; set; }
    }
}