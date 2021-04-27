using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CollectionDay
    {
        public int CollectionDayId { get; set; }

        public String DayOfWeek { get; set; }


        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}