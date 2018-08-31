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
    public class Wind
    {
        [BsonElement(elementName: "Speed")]
        public float Speed { get; set; }

        [BsonElement(elementName: "DirectionDegree")]
        public float DirectionDegree { get; set; }

        public Wind(float speed, float deg)
        {
            Speed = speed;
            DirectionDegree = deg;
        }
    }
}