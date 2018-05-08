using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class Util
    {
        public static DateTime ConvertToDate(string date, DateTime? date2)
        {
            try
            {
                return DateTime.Parse(date);
            }
            catch 
            {
                return DateTime.MinValue;
            }
        }

        internal static string ConvertToDate(DateTime? fecha)
        {
            throw new NotImplementedException();
        }
    }
}
