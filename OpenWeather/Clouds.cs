using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Objects
{
    [BsonIgnoreExtraElements]
    internal class Clouds
    {
        internal int All { get; set; }
        internal Clouds() { }
    }
}
