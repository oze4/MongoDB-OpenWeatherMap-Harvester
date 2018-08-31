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
    internal class Climate
    {
        [BsonElement(elementName: "Temperature")]
        internal float Temperature { get; set; }

        [BsonElement(elementName: "Pressure")]
        internal float Pressure { get; set; }

        [BsonElement(elementName: "Humidity")]
        internal float Humidity { get; set; }

        [BsonElement(elementName: "MinimumTemperature")]
        internal float MinimumTemperature { get; set; }

        [BsonElement(elementName: "MaximumTemperature")]
        internal float MaximumTemperature { get; set; }

        internal Climate(float temp, float pressure, float humidity, float temp_min, float temp_max)
        {
            Temperature = temp;
            Pressure = pressure;
            Humidity = humidity;
            MaximumTemperature = temp_max;
            MinimumTemperature = temp_min;
        }
    }
}