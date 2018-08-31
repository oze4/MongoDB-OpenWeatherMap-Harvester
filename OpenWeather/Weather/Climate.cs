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
    public class Climate
    {
        [BsonElement(elementName: "Temperature")]
        public float Temperature { get; set; }

        [BsonElement(elementName: "Pressure")]
        public float Pressure { get; set; }

        [BsonElement(elementName: "Humidity")]
        public float Humidity { get; set; }

        [BsonElement(elementName: "MinimumTemperature")]
        public float MinimumTemperature { get; set; }

        [BsonElement(elementName: "MaximumTemperature")]
        public float MaximumTemperature { get; set; }

        public Climate(float temp, float pressure, float humidity, float temp_min, float temp_max)
        {
            Temperature = temp;
            Pressure = pressure;
            Humidity = humidity;
            MaximumTemperature = temp_max;
            MinimumTemperature = temp_min;
        }
    }
}