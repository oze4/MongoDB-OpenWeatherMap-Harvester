using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.Core;

namespace OpenWeatherHarvester.Schema
{
    [BsonIgnoreExtraElements]
    internal class WeatherObject
    {
        [BsonElement(elementName: "Timestamp")]
        internal DateTime timestamp { get; private set; }

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
            //
            dateTime = TimeConverter.UtcToLocal(json["dt"].Value<double>());
            //
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

    [BsonIgnoreExtraElements]
    internal class Weather
    {
        [BsonElement(elementName: "Id")]
        internal string Id { get; set; }

        [BsonElement(elementName: "Main")]
        internal string Main { get; set; }

        [BsonElement(elementName: "Description")]
        internal string Description { get; set; }

        [BsonElement(elementName: "Icon")]
        internal string Icon { get; set; }

        internal Weather(string id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }
    }

    [BsonIgnoreExtraElements]
    internal class Sys
    {
        [BsonElement(elementName: "Type")]
        internal int Type { get; set; }

        [BsonElement(elementName: "Id")]
        internal int Id { get; set; }

        [BsonElement(elementName: "Message")]
        internal int Message { get; set; }

        [BsonElement(elementName: "Country")]
        internal string Country { get; set; }

        [BsonElement(elementName: "Sunrise")]
        internal DateTime Sunrise { get; set; }

        [BsonElement(elementName: "Sunset")]
        internal DateTime Sunset { get; set; }

        internal Sys(int type, int id, int message, string country, DateTime sunrise, DateTime sunset)
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
    internal class Main
    {
        [BsonElement(elementName: "Temp")]
        internal float Temp { get; set; }

        [BsonElement(elementName: "Pressure")]
        internal float Pressure { get; set; }

        [BsonElement(elementName: "Humidity")]
        internal float Humidity { get; set; }

        [BsonElement(elementName: "Temp_Min")]
        internal float Temp_Min { get; set; }

        [BsonElement(elementName: "Temp_Max")]
        internal float Temp_Max { get; set; }

        internal Main(float temp, float pressure, float humidity, float temp_min, float temp_max)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            Temp_Max = temp_max;
            Temp_Min = temp_min;
        }
    }

    [BsonIgnoreExtraElements]
    internal class Coordinate
    {
        [BsonElement(elementName: "Longitude")]
        internal int Longitude { get; set; }

        [BsonElement(elementName: "Latitude")]
        internal int Latitude { get; set; }

        internal Coordinate(int lon, int lat)
        {
            Longitude = lon;
            Latitude = lat;
        }
    }

    [BsonIgnoreExtraElements]
    internal class Clouds
    {
        [BsonElement(elementName: "All")]
        internal int All { get; set; }

        internal Clouds(int all)
        {
            All = all;
        }
    }

    [BsonIgnoreExtraElements]
    internal class Wind
    {
        [BsonElement(elementName: "Speed")]
        internal int Speed { get; set; }

        internal Wind(int speed)
        {
            Speed = speed;
        }
    }

}
