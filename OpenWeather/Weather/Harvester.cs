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
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace OpenWeatherHarvester.Weather
{
    internal class Harvester
    {
        private readonly string Url;


        /*
        private CurrentWeatherSummary InitializeObject(JObject json)
        {
            var baseIconUrl = string.Format("https://openweathermap.org/img/w"); // set icon
            var iconCode = json["weather"][0]["icon"].Value<string>(); // set icon            
            var sunrise_ = TimeConverter.UtcToLocal(json["sys"]["sunrise"].Value<double>());
            var sunset_ = TimeConverter.UtcToLocal(json["sys"]["sunset"].Value<double>());

            DateTime = TimeConverter.UtcToLocal(json["dt"].Value<double>());
            Timestamp = DateTimeFactory.ConvertToTimestamp(DateTime.Now);
            City = json["name"].Value<string>();
            Code = json["cod"].Value<int>();
            Base = json["base"].Value<string>();
            Visibility = json["visibility"].Value<int>();

            Clouds = new Clouds(
                json["clouds"]["all"].Value<int>()
                );

            Wind = new Wind(
                json["wind"]["speed"].Value<int>()
                );

            Main = new Measurements(
                json["main"]["temp"].Value<float>(),
                json["main"]["pressure"].Value<float>(),
                json["main"]["humidity"].Value<float>(),
                json["main"]["temp_min"].Value<float>(),
                json["main"]["temp_max"].Value<float>()
                );

            Weather = new CurrentWeatherDescription(
                json["weather"][0]["id"].Value<string>(),
                json["weather"][0]["main"].Value<string>(),
                json["weather"][0]["description"].Value<string>(),
                string.Format("{0}/{1}.png", baseIconUrl, iconCode) // set icon url
                );

            Sys = new Sun(
                json["sys"]["type"].Value<int>(),
                json["sys"]["id"].Value<int>(),
                json["sys"]["message"].Value<int>(),
                json["sys"]["country"].Value<string>(),
                DateTimeFactory.ConvertToTimestamp(sunrise_),
                DateTimeFactory.ConvertToTimestamp(sunset_)
                );

            Coordinates = new Coordinate(
                json["coord"]["lon"].Value<int>(),
                json["coord"]["lat"].Value<int>()
                );
        }*/
    }

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
            //var wo = new CurrentWeatherSummary(json);

            //insert into mongo 
           // BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(wo.ToBsonDocument());
           // collection.InsertOne(doc);
        }

        internal static void Get_SevenDayForecast_AndSaveToMongo(IMongoClient mongo)
        {
            var collection = mongo.GetDatabase("-").GetCollection<BsonDocument>("-");
            // get 7 day forecast
            var webreq = WebRequest.Create("-");
            var webResponse = webreq.GetResponse();
            var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(resp);
           // var wo = new CurrentWeatherSummary(json);

            //insert into mongo 
            //BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(wo.ToBsonDocument());
            //collection.InsertOne(doc);
        }
    }
}
