using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester
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
