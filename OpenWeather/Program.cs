using System;
using System.IO;
using System.Net;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.Schema.Objects;

namespace OpenWeatherHarvester
{
    class Program
    {
        private static IMongoClient Mongo { get; set; } = new MongoClient();

        static void Main(string[] args)
        {
            ConnectToMongo();
            var pauseTime = new TimeSpan(0, 1, 0); // (hrs, mins, secs);

            for (int i = 0; i < 2;)
            {
                Console.WriteLine("Gather weather...");
                Get_Weather_AndSaveToMongo();
                Console.WriteLine("Pausing for " + pauseTime.TotalMinutes + " minutes, at: " + DateTime.Now.ToString("MM-dd-yyyy--hh:mm:sstt"));
                Thread.Sleep(pauseTime);
            }

            //FinishedRunning();
        }

        private static void ConnectToMongo()
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


            Mongo = new MongoClient(url);
        }

        private static void Get_Weather_AndSaveToMongo()
        {
            var collection = Mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
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

        private static void Get_SevenDayForecast_AndSaveToMongo()
        {
            var collection = Mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
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
}
