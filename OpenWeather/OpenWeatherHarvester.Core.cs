/*
 * 
 *  THIS ENTIRE CLASS IS UNDER CONSTRUCTION SO... WOOSAH
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using OpenWeatherHarvester.Schema.Objects;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

//TODO: REORGANIZE THIS CLASS 

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

    //TODO: FINISH THIS CLASS
    internal class MongoDBWeatherFactory
    {
        internal IMongoClient ConnectToMongo()
        {
            var un = "-";
            var pw = "-";
            var authDatabase = "-";
            var mhosts = new string[]
            {
                "-:27017",
                "-:27017",
                "-:27017"
            };
            var mongoHosts = string.Join(",", mhosts);
            var replicaSet = "-";
            var url = string.Format(
                "mongodb://{0}:{1}@{2}/test?ssl=true&replicaSet={3}&authSource={4}&retryWrites=true",
                un, pw, mongoHosts, replicaSet, authDatabase
                );
            
            return new MongoClient(url);
        }

        internal static void Get_Weather_AndSaveToMongo(IMongoClient mongo)
        {
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
            // get weather 
            var webreq = WebRequest.Create("-");
            var webResponse = webreq.GetResponse();
            var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(resp);
            var wo = new WeatherObject(json);

            //insert into mongo 
            BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(wo.ToBsonDocument());
            collection.InsertOne(doc);
        }

        internal static void Get_SevenDayForecast_AndSaveToMongo(IMongoClient mongo)
        {
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
            // get 7 day forecast
            var webreq = WebRequest.Create("-");
            var webResponse = webreq.GetResponse();
            var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(resp);
            var wo = new WeatherObject(json);

            //insert into mongo 
            BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(wo.ToBsonDocument());
            collection.InsertOne(doc);
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

        private static void _how_to_connect_to_mongo_old()
        {
            /*
           // OLD build mongo connection
           var username = "-";
           var password = "-";
           var mongoHost = "-";
           var mongoCredential = new MongoCredential(
               "SCRAM-SHA-1",
               new MongoInternalIdentity("admin", username),
               new PasswordEvidence(password)
               );
           var address = new MongoServerAddress(string.Format("{0}", mongoHost));
           var settings = new MongoClientSettings()
           {
               Server = address,
               Credential = mongoCredential
           };
           var mongo = new MongoClient(settings);
           var database = mongo.GetDatabase("-");
           var collection = database.GetCollection<BsonDocument>("-");
           */
            Console.WriteLine("OpenWeatherHarvester.Core.DENIED");
        }
    }

}
