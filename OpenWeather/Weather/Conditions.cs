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
    internal class Conditions
    {
        [BsonElement(elementName: "Id")]
        internal string Id { get; set; }

        [BsonElement(elementName: "GeneralDescription")]
        internal string GeneralDescription { get; set; }

        [BsonElement(elementName: "DetailedDescription")]
        internal string DetailedDescription { get; set; }

        [BsonElement(elementName: "Icon")]
        internal string Icon { get; set; }

        internal Conditions(string id, string generalDescription, string detailedDescription, string icon)
        {
            Id = id;
            GeneralDescription = generalDescription;
            DetailedDescription = detailedDescription;
            Icon = icon;
        }
    }
}