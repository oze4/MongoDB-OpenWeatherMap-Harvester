using System;using System.IO;using System.Net;using System.Linq;using System.Threading;using MongoDB.Bson;using MongoDB.Bson.Serialization;using MongoDB.Driver;using System.Collections.Generic;using Newtonsoft.Json;using Newtonsoft.Json.Linq;namespace OpenWeatherHarvester{    class Program    {        static void Main(string[] args)        {            var pauseTime = new TimeSpan(0, 5, 0); // (hrs, mins, secs);
            for (int i = 0; i < 2;)            {                Console.WriteLine("Gathering weather....");                GetHoustonUsWeather_AndSaveToMongo();                Console.WriteLine("Pausing for " + pauseTime.TotalMinutes + " minutes, at: " + DateTime.Now.ToString("MM-dd-yyyy--hh:mm:sstt"));                Thread.Sleep(pauseTime);            }

            //FinishedRunning();
        }        private static void GetHoustonUsWeather_AndSaveToMongo()        {            var un = "-";            var pw = "-";            var authDatabase = "-";            var mhosts = new string[]
            {                "-:27017",                "-:27017",                "-:27017"            };            var mongoHosts = string.Join(",", mhosts);            var replicaSet = "-";            var url = string.Format(                "mongodb://{0}:{1}@{2}/test?ssl=true&replicaSet={3}&authSource={4}&retryWrites=true",
                un, pw, mongoHosts, replicaSet, authDatabase                );            var mongo = new MongoClient(url);            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");


            // get weather 
            var webreq = WebRequest.Create("-%yourOpenWeatherQueryURL%-");            var webResponse = webreq.GetResponse();            var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();            JObject json = JObject.Parse(resp);            var wo = new WeatherObject(json);

            //insert into mongo blah
            BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(wo.ToBsonDocument());            collection.InsertOne(doc);

        }        private static List<WeatherObject> GetMongoWeather(IMongoClient mongo)        {
            // grab all the shit again
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");            var documents = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();            List<WeatherObject> woList = new List<WeatherObject>();            foreach (var doc_ in documents) woList.Add(BsonSerializer.Deserialize<WeatherObject>(doc_));            return woList;        }        private static void FinishedRunning()        {            Console.ForegroundColor = ConsoleColor.Blue;            Console.WriteLine("\r\n\r\n\r\nDone.");            Console.ResetColor();            Console.ReadLine();        }    }}