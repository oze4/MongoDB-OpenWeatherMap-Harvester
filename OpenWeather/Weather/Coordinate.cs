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
    internal class Coordinate
    {
        [BsonElement(elementName: "Longitude")]
        internal int Longitude { get; set; }

        [BsonElement(elementName: "Latitude")]
        internal int Latitude { get; set; }

        internal Coordinate(int lon, int lat)
        {
            Longitude = lon;
            Latitude = lat;
        }
    }
}