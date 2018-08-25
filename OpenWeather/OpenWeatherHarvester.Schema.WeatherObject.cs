using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.Core;

namespace OpenWeatherHarvester.Schema
{
    [BsonIgnoreExtraElements]
    internal class WeatherObject
    {
        [BsonElement(elementName: "weather_id")]
        internal string weather_id { get; private set; }

        [BsonElement(elementName: "city")]
        internal string city { get; private set; }

        [BsonElement(elementName: "code")]
        internal int code { get; private set; }

        [BsonElement(elementName: "visibility")]
        internal int visibility { get; private set; }

        [BsonElement(elementName: "base")]
        internal string @base { get; private set; }

        [BsonElement(elementName: "dateTime")]
        internal DateTime dateTime { get; private set; }

        [BsonElement(elementName: "coord")]
        internal Coordinate coord { get; private set; }

        [BsonElement(elementName: "sys")]
        internal Sys sys { get; private set; } 

        [BsonElement(elementName: "Weather")]
        internal Weather weather { get; private set; }

        [BsonElement(elementName: "main")]
        internal Main main { get; private set; } 

        [BsonElement(elementName: "wind")]
        internal Wind wind { get; private set; } 

        [BsonElement(elementName: "clouds")]
        internal Clouds clouds { get; private set; }

        internal WeatherObject(JObject json)
        {
            _buildWeatherobjectFromWebResponse(json);
        }

        private void _buildWeatherobjectFromWebResponse(JObject json)
        {
            var baseIconUrl = string.Format("https://openweathermap.org/img/w"); // set icon
            var iconCode = json["weather"][0]["icon"].Value<string>(); // set icon

            dateTime = TimeConverter.UtcToLocal(json["dt"].Value<double>());
            weather_id = json["id"].Value<string>();
            city = json["name"].Value<string>();
            code = json["cod"].Value<int>();
            @base = json["base"].Value<string>();
            visibility = json["visibility"].Value<int>();

            clouds = new Clouds(
                json["clouds"]["all"].Value<int>()
                );

            wind = new Wind(
                json["wind"]["speed"].Value<int>()
                );

            main = new Main(
                json["main"]["temp"].Value<float>(),
                json["main"]["pressure"].Value<float>(),
                json["main"]["humidity"].Value<float>(),
                json["main"]["temp_min"].Value<float>(),
                json["main"]["temp_max"].Value<float>()
                );

            weather = new Weather(
                json["weather"][0]["id"].Value<string>(),
                json["weather"][0]["main"].Value<string>(),
                json["weather"][0]["description"].Value<string>(),
                string.Format("{0}/{1}.png", baseIconUrl, iconCode) // set icon url
                );

            sys = new Sys(
                json["sys"]["type"].Value<int>(),
                json["sys"]["id"].Value<int>(),
                json["sys"]["message"].Value<int>(),
                json["sys"]["country"].Value<string>(),
                TimeConverter.UtcToLocal(json["sys"]["sunrise"].Value<double>()),
                TimeConverter.UtcToLocal(json["sys"]["sunset"].Value<double>())
                );

            coord = new Coordinate(
                json["coord"]["lon"].Value<int>(),
                json["coord"]["lat"].Value<int>()
                );
        }
    }    
}
