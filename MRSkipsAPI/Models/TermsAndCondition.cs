using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class TermsAndCondition
    {
        public int TermsAndConditionId { get; set; }

        public string Text { get; set; }
        
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}