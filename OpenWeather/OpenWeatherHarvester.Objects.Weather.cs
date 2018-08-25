using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Schema
{
    [BsonIgnoreExtraElements]
    internal class Weather
    {
        [BsonElement(elementName: "Id")]
        internal string Id { get; set; }

        [BsonElement(elementName: "Main")]
        internal string Main { get; set; }

        [BsonElement(elementName: "Description")]
        internal string Description { get; set; }

        [BsonElement(elementName: "Icon")]
        internal string Icon { get; set; }

        internal Weather(string id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }
    }
}
