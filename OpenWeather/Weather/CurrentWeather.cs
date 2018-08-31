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
using OpenWeatherHarvester.City;

namespace OpenWeatherHarvester.Weather
{
    [BsonIgnoreExtraElements]
    internal class CurrentWeather
    {
        [BsonElement(elementName: "InternalTimestamp")]
        internal SanitizedDateTime InternalTimestamp { get; private set; }

        [BsonElement(elementName: "WeatherId")]
        internal string WeatherId { get; private set; }

        [BsonElement(elementName: "CityName")]
        internal string CityName { get; private set; }

        [BsonElement(elementName: "Code")]
        internal int Code { get; private set; }

        [BsonElement(elementName: "Visibility")]
        internal int Visibility { get; private set; }

        [BsonElement(elementName: "Sunrise")]
        internal SanitizedDateTime Sunrise { get; private set; }

        [BsonElement(elementName: "Sunset")]
        internal SanitizedDateTime Sunset { get; private set; }

        [BsonElement(elementName: "Base")]
        internal string Base { get; private set; }

        [BsonElement(elementName: "DateTimeOfWeatherCalculation")]
        internal SanitizedDateTime DateTimeOfWeatherCalculation { get; private set; }

        [BsonElement(elementName: "Coordinates")]
        internal Coordinate Coordinates { get; private set; }

        [BsonElement(elementName: "Conditions")]
        internal Conditions Weather { get; private set; }

        [BsonElement(elementName: "Main")]
        internal Climate Main { get; private set; }

        [BsonElement(elementName: "Wind")]
        internal Wind Wind { get; private set; }

        [BsonElement(elementName: "Clouds")]
        internal Clouds Clouds { get; private set; }

        internal CurrentWeather(
            SanitizedDateTime internaltimestamp,
            string weather_id,
            string city,
            int code,
            int visibility,
            string base_,
            SanitizedDateTime datetimeofweathercalculation,
            SanitizedDateTime sunrise,
            SanitizedDateTime sunset,
            Coordinate coordinates,
            Conditions conditions, 
            Climate climate, 
            Wind wind, 
            Clouds clouds
            )
        {
            InternalTimestamp = internaltimestamp;
            WeatherId = weather_id;
            CityName = city;
            Code = code;
            Visibility = visibility;
            Base = base_;
            DateTimeOfWeatherCalculation = datetimeofweathercalculation;
            Coordinates = coordinates;
            Sunrise = sunrise;
            Sunset = sunset;
            Weather = conditions;
            Main = climate;
            Wind = wind;
            Clouds = clouds;
        }

        
    }

}