using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester
{
    [BsonIgnoreExtraElements]
    internal class Main
    {
        internal int Temp { get; set; }
        internal int Pressure { get; set; }
        internal int Humidity { get; set; }
        internal int Temp_Min { get; set; }
        internal int Temp_Max { get; set; }
        internal Main() { }
    }
}
