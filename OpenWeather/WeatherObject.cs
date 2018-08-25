using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;

namespace OpenWeatherHarvester
{
    [BsonIgnoreExtraElements]
    internal class WeatherObject
    {
        [BsonElement(elementName: "weather_id")]
        internal string weather_id { get; set; }

        [BsonElement(elementName: "city")]
        internal string city { get; set; }

        [BsonElement(elementName: "code")]
        internal int code { get; set; }

        [BsonElement(elementName: "visibility")]
        internal int visibility { get; set; }

        [BsonElement(elementName: "base")]
        internal string @base { get; set; }

        [BsonElement(elementName: "dateTime")]
        internal string dateTime { get; set; }

        [BsonElement(elementName: "coord")]
        internal Coordinate coord { get; private set; } = new Coordinate();

        [BsonElement(elementName: "sys")]
        internal Sys sys { get; private set; } = new Sys();

        [BsonElement(elementName: "Weather")]
        internal Weather weather { get; private set; } = new Weather();

        [BsonElement(elementName: "main")]
        internal Main main { get; private set; } = new Main();

        [BsonElement(elementName: "wind")]
        internal Wind wind { get; private set; } = new Wind();

        [BsonElement(elementName: "clouds")]
        internal Clouds clouds { get; private set; } = new Clouds();

        internal WeatherObject(JObject json)
        {
            BuildWeatherobjectFromWebResponse(json);
        }

        private string _setDateTime(dynamic dt)
        {
            double ndt = (double)dt;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return epoch.AddSeconds(ndt).ToString("MM-dd-yyyy--hh:mm:sstt");
        }

        private void BuildWeatherobjectFromWebResponse(JObject responseAsJson)
        {
            // example | Console.WriteLine(json["wind"]["speed"]);
            this.dateTime = responseAsJson["dt"].Value<string>();
            this.weather_id = responseAsJson["id"].Value<string>();
            this.city = responseAsJson["name"].Value<string>();
            this.code = responseAsJson["cod"].Value<int>();
            this.@base = responseAsJson["base"].Value<string>();
            this.visibility = responseAsJson["visibility"].Value<int>(); 
            /*
            this.main.Temp = responseAsJson.main.Temp;
            this.main.Pressure = responseAsJson.main.Pressure;
            this.main.Humidity = responseAsJson.main.Humidity;
            this.main.Temp_Min = responseAsJson.main.Temp_Min;
            this.main.Temp_Max = responseAsJson.main.Temp_Max;
            this.clouds.All = responseAsJson.clouds.All;
            this.coord.Longitude = responseAsJson.coord.Longitude;
            this.coord.Latitude = responseAsJson.coord.Latitude;
            this.weather.Id = responseAsJson.weather.Id;
            this.weather.Main = responseAsJson.weather.Main;
            this.weather.Description = responseAsJson.weather.Description;
            this.wind.Speed = responseAsJson.wind.Speed;
            this.wind.Degree = responseAsJson.wind.Degree;
            this.sys.Type = responseAsJson.sys.Type;
            this.sys.Id = responseAsJson.sys.Id;
            this.sys.Message = responseAsJson.sys.Message;
            this.sys.Country = responseAsJson.sys.Country;
            this.sys.Sunrise = responseAsJson.sys.Sunrise;
            this.sys.Sunset = responseAsJson.sys.Sunset;
            */
        }

    }

    [BsonIgnoreExtraElements]
    internal class Coordinate
    {
        internal int Longitude { get; set; }
        internal int Latitude { get; set; }
        internal Coordinate() { }
    }

    [BsonIgnoreExtraElements]
    internal class Sys
    {
        internal int Type { get; set; }
        internal int Id { get; set; }
        internal int Message { get; set; }
        internal string Country { get; set; }
        internal string Sunrise { get; set; }
        internal string Sunset { get; set; }
        internal Sys() { }
    }

    [BsonIgnoreExtraElements]
    internal class Weather
    {
        internal int Id { get; set; }
        internal string Main { get; set; }
        internal string Description { get; set; }
        internal Weather() { }
    }

    [BsonIgnoreExtraElements]
    internal class Main
    {
        internal int Temp { get; set; }
        internal int Pressure { get; set; }
        internal int Humidity { get; set; }
        internal int Temp_Min { get; set; }
        internal int Temp_Max { get; set; }
        internal Main() { }
    }

    [BsonIgnoreExtraElements]
    internal class Wind
    {
        internal int Speed { get; set; }
        internal int Degree { get; set; }
        internal Wind() { }
    }

    [BsonIgnoreExtraElements]
    internal class Clouds
    {
        internal int All { get; set; }
        internal Clouds() { }
    }
}
