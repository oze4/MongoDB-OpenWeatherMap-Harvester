using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester
{
    [BsonIgnoreExtraElements]
    internal class Coordinate
    {
        internal int Longitude { get; set; }
        internal int Latitude { get; set; }
        internal Coordinate() { }
    }
}
