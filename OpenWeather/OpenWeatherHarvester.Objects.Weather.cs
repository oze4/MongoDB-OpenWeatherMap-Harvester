using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Objects
{
    [BsonIgnoreExtraElements]
    internal class Weather
    {
        internal int Id { get; set; }
        internal string Main { get; set; }
        internal string Description { get; set; }
        internal string Icon { get; set; }
        internal Weather() { }
    }
}
