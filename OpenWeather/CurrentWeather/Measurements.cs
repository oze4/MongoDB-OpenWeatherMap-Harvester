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

namespace OpenWeatherHarvester.CurrentWeather
{

    [BsonIgnoreExtraElements]
    internal class Measurements
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

        internal Measurements(float temp, float pressure, float humidity, float temp_min, float temp_max)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            Temp_Max = temp_max;
            Temp_Min = temp_min;
        }
    }
}