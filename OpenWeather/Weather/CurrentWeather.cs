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

namespace csOpenWeather.Weather
{
    [BsonIgnoreExtraElements]
    public class CurrentWeather
    {
        [BsonElement(elementName: "csTimestamp")]
        public HarvesterDateTime CsTimestamp { get; private set; }

        [BsonElement(elementName: "WeatherId")]
        public string WeatherId { get; private set; }

        [BsonElement(elementName: "CityName")]
        public string CityName { get; private set; }

        [BsonElement(elementName: "Code")]
        public int Code { get; private set; }

        [BsonElement(elementName: "Visibility")]
        public int Visibility { get; private set; }

        [BsonElement(elementName: "Sunrise")]
        public HarvesterDateTime Sunrise { get; private set; }

        [BsonElement(elementName: "Sunset")]
        public HarvesterDateTime Sunset { get; private set; }

        [BsonElement(elementName: "DateTimeOfWeatherCalculation")]
        public HarvesterDateTime DateTimeOfWeatherCalculation { get; private set; }

        [BsonElement(elementName: "Coordinates")]
        public Coordinate Coordinates { get; private set; }

        [BsonElement(elementName: "Conditions")]
        public Conditions Conditions { get; private set; }

        [BsonElement(elementName: "Main")]
        public Climate Climate { get; private set; }

        [BsonElement(elementName: "Wind")]
        public Wind Wind { get; private set; }

        [BsonElement(elementName: "Clouds")]
        public Clouds Clouds { get; private set; }

        public CurrentWeather(
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
            CsTimestamp = internaltimestamp;
            WeatherId = weather_id;
            CityName = cityname;
            Code = code;
            Visibility = visibility;
            DateTimeOfWeatherCalculation = datetimeofweathercalculation;
            Coordinates = coordinates;
            Sunrise = sunrise;
            Sunset = sunset;
            Conditions = conditions;
            Climate = climate;
            Wind = wind;
            Clouds = clouds;
        }

        
    }

}