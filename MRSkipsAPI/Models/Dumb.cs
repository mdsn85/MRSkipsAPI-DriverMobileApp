using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Dumb
    {
        public int DumbId { get; set; }

        public int DumpLocationId { get; set; }
        public virtual DumpLocation DumpLocation { get; set; }

        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }

        public DateTime DumpDate { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public float? LandFillWeight { get; set; }

        public virtual ICollection<TripSheetDeatails_skip> TripSheetDeatails_skips { get; set; }
    }
}