/*


                                
                     _|      _|       _|_|_|_|_|    
                     _|_|  _|_|     _|          _|  
                     _|  _|  _|   _|    _|_|_|  _|  
                     _|      _|   _|  _|    _|  _|  
                     _|      _|   _|    _|_|_|_|    
                                    _|              
                                      _|_|_|_|_|_|  


*/
using System;

namespace csOpenWeather
{

    internal class DateTimeFactory
    {
        internal static string ConvertToTimestamp(DateTime dateTime) // *jan 1, 1970 at midnight*, in format; 'mmddyyy_hhMMsstt' = 01011970_120000AM
        {
            var dayofweek = dateTime.DayOfWeek;
            var shortdtstring = dateTime.ToShortDateString();
            var timeofday = dateTime.TimeOfDay;
            var h = timeofday.Hours;
            var m = timeofday.Minutes;
            var s = timeofday.Seconds;
            return string.Format("{0}, {1} {2}:{3}:{4}", dayofweek, shortdtstring, h, m, s);
        }

        internal static DateTime FindStartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}