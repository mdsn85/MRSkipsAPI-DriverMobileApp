using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ContractFile
    {

        public int ContractFileId { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }


        public DateTime ValidUntil { get; set; }

        public virtual Contract Contract { get; set; }
        public int? ContractId { get; set; }
    }
}