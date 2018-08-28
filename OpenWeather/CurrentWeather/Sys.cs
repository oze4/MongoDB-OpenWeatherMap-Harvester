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
    internal class Sys
    {
        [BsonElement(elementName: "Type")]
        internal int Type { get; set; }

        [BsonElement(elementName: "Id")]
        internal int Id { get; set; }

        [BsonElement(elementName: "Message")]
        internal int Message { get; set; }

        [BsonElement(elementName: "Country")]
        internal string Country { get; set; }

        [BsonElement(elementName: "Sunrise")]
        internal string Sunrise { get; set; }

        [BsonElement(elementName: "Sunset")]
        internal string Sunset { get; set; }

        internal Sys(int type, int id, int message, string country, string sunrise, string sunset)
        {
            Type = type;
            Id = id;
            Message = message;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
    }
}