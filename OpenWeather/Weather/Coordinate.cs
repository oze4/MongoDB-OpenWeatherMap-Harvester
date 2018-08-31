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
    public class Coordinate
    {
        [BsonElement(elementName: "Longitude")]
        public int Longitude { get; set; }

        [BsonElement(elementName: "Latitude")]
        public int Latitude { get; set; }

        public Coordinate(int lon, int lat)
        {
            Longitude = lon;
            Latitude = lat;
        }
    }
}