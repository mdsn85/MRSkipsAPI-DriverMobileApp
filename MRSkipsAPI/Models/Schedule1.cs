using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum ScheduleType { Daily, Alternative, WeekDay, Datewise, Days, CallBased}

    public class Schedule1
    {
        //[Key]
        //[Index]
        [ForeignKey("Contract")]
        public int Schedule1Id { get; set; }
        // [Key]
        // [ForeignKey("Contract")]
        // public int ContractId { get; set; }

        public String Text { get; set; }

        [DisplayFormat(NullDisplayText = "Schedule Type")]
        public ScheduleType? ScheduleType { get; set; }


        public int? AlternativeStart { get; set; }

        //public DateTime AlternativeLastService { get; set; }

        //public virtual ICollection<CollectionDate> CollectionDates { get; set; }
        //public virtual ICollection<CollectionDay> CollectionDays { get; set; }
        //public virtual ICollection<CallBased> CallBaseds { get; set; }

        /// public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }

}