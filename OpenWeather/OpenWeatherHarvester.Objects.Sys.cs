using System;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Schema
{
    [BsonIgnoreExtraElements]
    internal class Sys
    {
        [BsonElement(elementName: "Type")]
        internal int Type { get; set; }

        [BsonElement(elementName: "Id")]
        internal int Id { get; set; }

        [BsonElement(elementName: "Message")]
        internal int Message { get; set; }

        [BsonElement(elementName: "Country")]
        internal string Country { get; set; }

        [BsonElement(elementName: "Sunrise")]
        internal DateTime Sunrise { get; set; }

        [BsonElement(elementName: "Sunset")]
        internal DateTime Sunset { get; set; }

        internal Sys(int type, int id, int message, string country, DateTime sunrise, DateTime sunset)
        {
            Type = type;
            Id = id;
            Message = message;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
    }
}
