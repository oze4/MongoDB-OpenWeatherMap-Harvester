using System;
using System.Collections.Generic;
using System.Linq;
using OpenWeatherHarvester.Schema.Objects;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherHarvester.Core
{
    internal class TimeConverter
    {
        internal static DateTime UtcToLocal(double utcDateTimeString)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return epoch.AddSeconds(utcDateTimeString);
        }
    }

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

        internal static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

    internal class Misc
    {
        private static List<WeatherObject> GetMongoWeather(IMongoClient mongo)
        {
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
            var documents = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();
            List<WeatherObject> woList = new List<WeatherObject>();
            foreach (var doc_ in documents) woList.Add(BsonSerializer.Deserialize<WeatherObject>(doc_));
            return woList;
        }

        private static void FinishedRunning()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\n\r\n\r\nDone.");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
