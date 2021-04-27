using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public static  class DateFormat
    {

        public static string SetFormat(DateTime Q)
        {
            string DateS = "";

            DateS = Q.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            return DateS;
        }
}
}