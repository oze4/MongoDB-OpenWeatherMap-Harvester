using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Objects
{
    [BsonIgnoreExtraElements]
    internal class Wind
    {
        internal int Speed { get; set; }
        internal int Degree { get; set; }
        internal Wind() { }
    }
}
