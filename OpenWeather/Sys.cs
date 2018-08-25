using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester
{
    [BsonIgnoreExtraElements]
    internal class Sys
    {
        internal int Type { get; set; }
        internal int Id { get; set; }
        internal int Message { get; set; }
        internal string Country { get; set; }
        internal string Sunrise { get; set; }
        internal string Sunset { get; set; }
        internal Sys() { }
    }
}
