using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class Util
    {
        public static DateTime ConvertToDate(string date, DateTime fecha)
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

       
    }
}
