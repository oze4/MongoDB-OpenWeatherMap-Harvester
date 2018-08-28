/*


                                
                     _|      _|       _|_|_|_|_|    
                     _|_|  _|_|     _|          _|  
                     _|  _|  _|   _|    _|_|_|  _|  
                     _|      _|   _|  _|    _|  _|  
                     _|      _|   _|    _|_|_|_|    
                                    _|              
                                      _|_|_|_|_|_|  


*/
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.CurrentWeather;
using System.IO;
using System.Net;

namespace OpenWeatherHarvester.HarvestingFactory.CurrentWeather
{
    class MongoTasks
    {
        internal static void Get_Weather_AndSaveToMongo(IMongoClient mongo)
        {
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
            // get weather 
            var webreq = WebRequest.Create("-");
            var webResponse = webreq.GetResponse();
            var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(resp);
            var wo = new CurrentWeatherSummary(json);

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
            var wo = new CurrentWeatherSummary(json);

            //insert into mongo 
            BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(wo.ToBsonDocument());
            collection.InsertOne(doc);
        }
    }
}
