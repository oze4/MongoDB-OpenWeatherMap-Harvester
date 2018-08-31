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
    internal class Wind
    {
        [BsonElement(elementName: "Speed")]
        internal float Speed { get; set; }

        [BsonElement(elementName: "DirectionDegree")]
        internal float DirectionDegree { get; set; }

        internal Wind(float speed, float deg)
        {
            Speed = speed;
            DirectionDegree = deg;
        }
    }
}