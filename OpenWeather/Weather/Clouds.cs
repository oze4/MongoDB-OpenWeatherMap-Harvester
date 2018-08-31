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
    public class Clouds
    {
        [BsonElement(elementName: "CloudCoverPercentage")]
        public int CloudCoverPercentage { get; set; }

        public Clouds(int cloudcoverpercentage)
        {
            CloudCoverPercentage = cloudcoverpercentage;
        }
    }
}