using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester
{
    [BsonIgnoreExtraElements]
    internal class Wind
    {
        internal int Speed { get; set; }
        internal int Degree { get; set; }
        internal Wind() { }
    }
}
