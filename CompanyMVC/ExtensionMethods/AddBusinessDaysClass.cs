using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyMVC.ExtensionMethods
{
    public static class AddBusinessDaysClass
    {
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            while(days > 1)
            {

                current = current.AddDays(1);
                if ((current.DayOfWeek != DayOfWeek.Saturday &&
                         current.DayOfWeek != DayOfWeek.Sunday))
                {
                    days--;
                }

            }
            return current;
        }
    }
}