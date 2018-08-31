/*


                                
                     _|      _|       _|_|_|_|_|    
                     _|_|  _|_|     _|          _|  
                     _|  _|  _|   _|    _|_|_|  _|  
                     _|      _|   _|  _|    _|  _|  
                     _|      _|   _|    _|_|_|_|    
                                    _|              
                                      _|_|_|_|_|_|  


*/

using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Weather
{
    [BsonIgnoreExtraElements]
    internal class CurrentWeather
    {
        [BsonElement(elementName: "InternalTimestamp")]
        internal HarvesterDateTime InternalTimestamp { get; private set; }

        [BsonElement(elementName: "WeatherId")]
        internal string WeatherId { get; private set; }

        [BsonElement(elementName: "CityName")]
        internal string CityName { get; private set; }

        [BsonElement(elementName: "Code")]
        internal int Code { get; private set; }

        [BsonElement(elementName: "Visibility")]
        internal int Visibility { get; private set; }

        [BsonElement(elementName: "Sunrise")]
        internal HarvesterDateTime Sunrise { get; private set; }

        [BsonElement(elementName: "Sunset")]
        internal HarvesterDateTime Sunset { get; private set; }

        [BsonElement(elementName: "DateTimeOfWeatherCalculation")]
        internal HarvesterDateTime DateTimeOfWeatherCalculation { get; private set; }

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
            HarvesterDateTime internaltimestamp,
            string weather_id,
            string cityname,
            int code,
            int visibility,
            HarvesterDateTime datetimeofweathercalculation,
            HarvesterDateTime sunrise,
            HarvesterDateTime sunset,
            Coordinate coordinates,
            Conditions conditions, 
            Climate climate, 
            Wind wind, 
            Clouds clouds
            )
        {
            InternalTimestamp = internaltimestamp;
            WeatherId = weather_id;
            CityName = cityname;
            Code = code;
            Visibility = visibility;
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