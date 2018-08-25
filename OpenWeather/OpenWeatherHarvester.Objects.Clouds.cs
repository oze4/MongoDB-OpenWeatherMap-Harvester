using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Objects
{
    [BsonIgnoreExtraElements]
    internal class Clouds
    {
        [BsonElement(elementName: "All")]
        internal int All { get; set; }

        internal Clouds(int all)
        {
            All = all;
        }
    }
}
