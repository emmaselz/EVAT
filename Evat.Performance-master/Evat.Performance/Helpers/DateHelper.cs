using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evat.Performance.Helpers
{
    public static class DateHelper
    {
        public static DateTime CurrentDate()
            => DateTime.Now;

        internal static double TimeDifference(DateTime current, DateTime startAt)
        {
            return current.Subtract(startAt).TotalSeconds;
        }
    }
}
