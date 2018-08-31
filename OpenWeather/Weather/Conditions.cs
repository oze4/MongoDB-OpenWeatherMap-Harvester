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
    public class Conditions
    {
        [BsonElement(elementName: "Id")]
        public string Id { get; set; }

        [BsonElement(elementName: "GeneralDescription")]
        public string GeneralDescription { get; set; }

        [BsonElement(elementName: "DetailedDescription")]
        public string DetailedDescription { get; set; }

        [BsonElement(elementName: "Icon")]
        public string Icon { get; set; }

        public Conditions(string id, string generalDescription, string detailedDescription, string icon)
        {
            Id = id;
            GeneralDescription = generalDescription;
            DetailedDescription = detailedDescription;
            Icon = icon;
        }
    }
}