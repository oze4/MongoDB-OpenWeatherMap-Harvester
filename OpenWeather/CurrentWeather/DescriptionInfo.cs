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
    internal class DescriptionInfo
    {
        [BsonElement(elementName: "Id")]
        internal string Id { get; set; }

        [BsonElement(elementName: "Main")]
        internal string Main { get; set; }

        [BsonElement(elementName: "Description")]
        internal string Description { get; set; }

        [BsonElement(elementName: "Icon")]
        internal string Icon { get; set; }

        internal DescriptionInfo(string id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }
    }
}