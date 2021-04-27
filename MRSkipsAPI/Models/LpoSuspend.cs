using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class LpoSuspend
    {
        public int LpoSuspendId { get; set; }

        public String Reason { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//@"{0:dd\/MM\/yyyy}
        public DateTime SuspendDate { get; set; }


        public int LpoId { get; set; }//(active, expired, terminated, suspend)
        public virtual LPO LPOs { get; set; }
    }
}