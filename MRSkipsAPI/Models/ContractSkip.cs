using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ContractSkip
    {
        public int ContractSkipId { get; set; }

        public String SkipSize { get; set; }
        public int ProductId { get; set; }

        public String SkipSerialNumber { get; set; }

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}