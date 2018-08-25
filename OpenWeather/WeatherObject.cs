using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;

namespace OpenWeatherHarvester.Objects
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
            _buildWeatherobjectFromWebResponse(json);
        }

        private DateTime _convertUTCtoLocalTime(double utcDateTimeString)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return epoch.AddSeconds(utcDateTimeString);
        }

        private void _buildWeatherobjectFromWebResponse(JObject json)
        {

            dateTime = _convertUTCtoLocalTime(json["dt"].Value<double>());
            weather_id = json["id"].Value<string>();
            city = json["name"].Value<string>();
            code = json["cod"].Value<int>();
            @base = json["base"].Value<string>();
            visibility = json["visibility"].Value<int>();
            main.Temp = json["main"]["temp"].Value<int>();
            main.Pressure = json["main"]["pressure"].Value<int>();
            main.Humidity = json["main"]["humidity"].Value<int>();
            main.Temp_Min = json["main"]["temp_min"].Value<int>();
            main.Temp_Max = json["main"]["temp_max"].Value<int>();
            clouds.All = json["clouds"]["all"].Value<int>();
            coord.Longitude = json["coord"]["lon"].Value<int>();
            coord.Latitude = json["coord"]["lat"].Value<int>();
            weather.Id = json["weather"]["id"].Value<int>();
            weather.Main = json["weather"]["main"].Value<string>();
            weather.Description = json["weather"]["description"].Value<string>();            
            var baseIconUrl = string.Format("https://openweathermap.org/img/w/"); // set icon
            var iconCode = json["weather"]["icon"].Value<string>(); // set icon
            weather.Icon = string.Format("{0}/{1}.png", baseIconUrl, iconCode); // set icon
            wind.Speed = json["wind"]["speed"].Value<int>();
            wind.Degree = json["wind"]["deg"].Value<int>();
            sys.Type = json["sys"]["type"].Value<int>();
            sys.Id = json["sys"]["id"].Value<int>();
            sys.Message = json["sys"]["mssage"].Value<int>();
            sys.Country = json["sys"]["country"].Value<string>();
            sys.Sunrise = json["sys"]["sunrise"].Value<string>();
            sys.Sunset = json["sys"]["sunset"].Value<string>();

        }

    }    

}
