using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CollectionCanceledDate
    {
        public int CollectionCanceledDateId { get; set; }

        public DateTime ColectionCanceled_Date { get; set; }

        public int NumOfSkips { get; set; }


        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}