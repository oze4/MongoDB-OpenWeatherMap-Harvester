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
    internal class Clouds
    {
        [BsonElement(elementName: "All")]
        internal int All { get; set; }

        internal Clouds(int all)
        {
            All = all;
        }
    }
}