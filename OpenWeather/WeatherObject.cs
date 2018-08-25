using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester
{
    [BsonIgnoreExtraElements]
    internal class WeatherObject
    {
        [BsonElement(elementName: "weather_id")]
        internal string weather_id { get; set; }

        [BsonElement(elementName: "name")]
        internal string name { get; set; }

        [BsonElement(elementName: "code")]
        internal int code { get; set; }

        [BsonElement(elementName: "visibility")]
        internal int visibility { get; set; }

        [BsonElement(elementName: "base_")]
        internal string base_ {get;set;}

        [BsonElement(elementName: "dt")]
        internal int dt { get; set; }

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

        internal WeatherObject() { }

        internal void BuildWeatherobjectFromWebResponse(WebResponse webResponse)
        {
            dynamic response = JsonConvert.DeserializeObject(
                new StreamReader(webResponse.GetResponseStream()).ReadToEnd()
                );
            this.dt = response.dt;
            this.weather_id = response.id;
            this.name = response.name;
            this.code = response.cod;
            this.base_ = response["base"];
            this.visibility = response.visibility;
            this.main.Temp = response.main.temp;
            this.main.Pressure = response.main.pressure;
            this.main.Humidity = response.main.humidity;
            this.main.Temp_Min = response.main.temp_min;
            this.main.Temp_Max = response.main.temp_max;
            this.clouds.All = response.clouds.all;
            this.coord.Longitude = response.coord.lon;
            this.coord.Latitude = response.coord.lat;
            this.weather.Id = response.weather.id;
            this.weather.Main = response.weather.main;
            this.weather.Description = response.weather.description;
            this.wind.Speed = response.wind.speed;
            this.wind.Degree = response.wind.deg;
            this.sys.Type = response.sys.type;
            this.sys.Id = response.sys.id;
            this.sys.Message = response.sys.message;
            this.sys.Country = response.sys.country;
            this.sys.Sunrise = response.sys.sunrise;
            this.sys.Sunset = response.sys.sunset;
        }

    }

    [BsonIgnoreExtraElements]
    internal class Coordinate
    {
        internal int Longitude { get; set; }
        internal int Latitude { get; set; }
        internal Coordinate() { }
        internal Coordinate(int longitute, int latitude)
        {
            Longitude = longitute;
            Latitude = latitude;
        }
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
        internal Sys(int type, int id, int message, string country, string sunrise, string sunset)
        {
            Type = type;
            Id = id;
            Message = message;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
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
