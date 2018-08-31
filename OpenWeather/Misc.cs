﻿/*


                                
                     _|      _|       _|_|_|_|_|    
                     _|_|  _|_|     _|          _|  
                     _|  _|  _|   _|    _|_|_|  _|  
                     _|      _|   _|  _|    _|  _|  
                     _|      _|   _|    _|_|_|_|    
                                    _|              
                                      _|_|_|_|_|_|  


*/
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using csOpenWeather.Weather;

namespace csOpenWeather
{
    internal class Misc
    {
        private static List<CurrentWeather> GetMongoWeather(IMongoClient mongo)
        {
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
            var documents = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();
            List<CurrentWeather> woList = new List<CurrentWeather>();
            foreach (var doc_ in documents) woList.Add(BsonSerializer.Deserialize<CurrentWeather>(doc_));
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