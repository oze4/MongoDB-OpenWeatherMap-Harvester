using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;

namespace OpenWeatherHarvester
{
    class Program
    {
        static void Main(string[] args)
        {
            var pauseTime = new TimeSpan(0, 5, 0); // (hrs, mins, secs);
            for (int i = 0; i < 2;)
            {
                Console.WriteLine("Gather Houston, US weather...");
                GetHoustonUsWeather_AndSaveToMongo();
                Console.WriteLine("Pausing for " + pauseTime.TotalMinutes + " minutes, at: " + DateTime.Now.ToString("MM-dd-yyyy--hh:mm:sstt"));
                Thread.Sleep(pauseTime);
            }

            //FinishedRunning();
        }

        private static void GetHoustonUsWeather_AndSaveToMongo()
        {
            // build mongo connection
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
            var database = mongo.GetDatabase("Domo");
            var collection = database.GetCollection<BsonDocument>("Weather");
            
            // get weather 
            var webreq = WebRequest.Create("-");
            var webresp = webreq.GetResponse();
            var resp = new StreamReader(webresp.GetResponseStream()).ReadToEnd();
            
            //insert into mongo 
            BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(resp);            
            collection.InsertOne(doc);            
        }

        private static List<WeatherObject> GetMongoWeather(IMongoClient mongo)
        {
            // grab all the shit again
            var collection = mongo.GetDatabase("Weather").GetCollection<BsonDocument>("HoustonUs");
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
