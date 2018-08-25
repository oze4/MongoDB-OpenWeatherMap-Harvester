using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Schema
{
    [BsonIgnoreExtraElements]
    internal class Wind
    {
        [BsonElement(elementName: "Speed")]
        internal int Speed { get; set; }

        internal Wind(int speed)
        {
            Speed = speed;
        }
    }
}
