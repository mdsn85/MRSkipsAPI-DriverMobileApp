using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class FuelRecipt
    {

        public int FuelReciptId { get; set; }

        public float? Rate { get; set; }

        public float? Amount { get; set; }

        public string unit { get; set; }

        public float Qty { get; set; }



        public int FuelProviderId { get; set; }
        public virtual FuelProvider FuelProvider { get; set; }
        //public string Provider { get; set; }

        //providerid
        //providers

        [Display(Name = "Recipt Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ReciptDate { get; set; }

        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }


        [Display(Name = "Vehicle Plate")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public String ImgRecipt { get; set; }


        [Display(Name = "Create Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }


        public int? ShiftId { get; set; }
        public virtual Shift Shift { get; set; }

        public string RecieptNo { get; set; }

    }
}