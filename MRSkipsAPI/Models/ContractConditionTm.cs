using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ContractConditionTm
    {
        public int ContractConditionTmId { get; set; }
        public int Conditionsequence { get; set; }
        public string TextCondition { get; set; }
        public string TextConditionart2 { get; set; }
    }
}