using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Objects
{
    [BsonIgnoreExtraElements]
    internal class Coordinate
    {
        internal int Longitude { get; set; }
        internal int Latitude { get; set; }
        internal Coordinate() { }
    }
}
