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
    internal class Clouds
    {
        [BsonElement(elementName: "CloudCoverPercentage")]
        internal int CloudCoverPercentage { get; set; }

        internal Clouds(int cloudcoverpercentage)
        {
            CloudCoverPercentage = cloudcoverpercentage;
        }
    }
}