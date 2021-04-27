using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ReceiptFile
    {

        public int ReceiptFileId { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }

        public virtual ICollection<SecurityDeposit> SecurityDeposits { get; set; }

    }
}