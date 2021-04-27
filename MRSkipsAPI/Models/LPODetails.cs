using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class LPODetails
    {

        public String ProductId { get; set; }//(Quantity Base)
        public String NoOfSkips { get; set; }//(Quantity Base)
        public String ServiceRequestedQuantity { get; set; }//(Quantity Base)
    }
}