using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class RequestApprovalType
    {
        public int RequestApprovalTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestApproval> RequestApprovals { get; set; }
    }
}