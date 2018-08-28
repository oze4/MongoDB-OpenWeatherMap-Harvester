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
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.City;

namespace OpenWeatherHarvester.CurrentWeather
{
    [BsonIgnoreExtraElements]
    internal class CurrentWeatherSummary
    {
        [BsonElement(elementName: "Timestamp")]
        internal string Timestamp { get; private set; }

        [BsonElement(elementName: "WeatherId")]
        internal string WeatherId { get; private set; }

        [BsonElement(elementName: "City")]
        internal string City { get; private set; }

        [BsonElement(elementName: "Code")]
        internal int Code { get; private set; }

        [BsonElement(elementName: "Visibility")]
        internal int Visibility { get; private set; }

        [BsonElement(elementName: "Base")]
        internal string Base { get; private set; }

        [BsonElement(elementName: "DateTime")]
        internal DateTime DateTime { get; private set; }

        [BsonElement(elementName: "Coordinates")]
        internal Coordinate Coordinates { get; private set; }

        [BsonElement(elementName: "Sys")]
        internal Sys Sys { get; private set; }

        [BsonElement(elementName: "Weather")]
        internal CurrentWeatherDescription Weather { get; private set; }

        [BsonElement(elementName: "Main")]
        internal CurrentWeatherMeasurements Main { get; private set; }

        [BsonElement(elementName: "Wind")]
        internal Wind Wind { get; private set; }

        [BsonElement(elementName: "Clouds")]
        internal Clouds Clouds { get; private set; }

        internal CurrentWeatherSummary(JObject json)
        {
            InitializeObject(json);
        }

        private void InitializeObject(JObject json)
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

            Main = new CurrentWeatherMeasurements(
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

            Sys = new Sys(
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
        }
    }

}