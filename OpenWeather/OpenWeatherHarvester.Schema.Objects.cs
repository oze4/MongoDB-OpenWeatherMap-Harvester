using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using OpenWeatherHarvester.Core;

namespace OpenWeatherHarvester.Schema.Objects
{
    [BsonIgnoreExtraElements]
    internal class WeatherObject
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
        internal Weather Weather { get; private set; }

        [BsonElement(elementName: "Main")]
        internal Main Main { get; private set; }

        [BsonElement(elementName: "Wind")]
        internal Wind Wind { get; private set; }

        [BsonElement(elementName: "Clouds")]
        internal Clouds Clouds { get; private set; }

        internal WeatherObject(JObject json)
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

            Main = new Main(
                json["main"]["temp"].Value<float>(),
                json["main"]["pressure"].Value<float>(),
                json["main"]["humidity"].Value<float>(),
                json["main"]["temp_min"].Value<float>(),
                json["main"]["temp_max"].Value<float>()
                );

            Weather = new Weather(
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
        internal string Sunrise { get; set; }

        [BsonElement(elementName: "Sunset")]
        internal string Sunset { get; set; }

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
