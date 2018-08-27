using System;
using System.IO;
using System.Net;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OpenWeatherHarvester.Core;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.Schema.Objects;

namespace OpenWeatherHarvester
{
    class Program
    {
        // ICK.. 

        // THIS IS UNDER CONSTRUCTION AS WELL...

        //
        private static IMongoClient Mongo { get; set; } = new MongoClient();

        static void Main(string[] args)
        {
            Mongo = new MongoDBWeatherFactory().ConnectToMongo();
            var pauseTime = new TimeSpan(0, 1, 0); // (hrs, mins, secs);

            for (string exit = "No"; exit != "Yes";)
            {
                try
                {
                    Console.WriteLine("Gather weather...");
                    MongoDBWeatherFactory.Get_Weather_AndSaveToMongo(Mongo);
                    MongoDBWeatherFactory.Get_SevenDayForecast_AndSaveToMongo(Mongo);

                    Console.WriteLine(
                        "Pausing for " +
                        pauseTime.TotalMinutes +
                        " minutes, at: " +
                        DateTime.Now.ToString("MM-dd-yyyy--hh:mm:sstt")
                        );

                    Thread.Sleep(pauseTime);
                }
                catch
                {
                    exit = "Yes";
                }
            }
        }
    }
}
