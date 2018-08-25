using MongoDB.Bson.Serialization.Attributes;

namespace OpenWeatherHarvester.Schema
{
    [BsonIgnoreExtraElements]
    internal class Main
    {
        [BsonElement(elementName: "Temp")]
        internal int Temp { get; set; }

        [BsonElement(elementName: "Pressure")]
        internal int Pressure { get; set; }

        [BsonElement(elementName: "Humidity")]
        internal int Humidity { get; set; }

        [BsonElement(elementName: "Temp_Min")]
        internal int Temp_Min { get; set; }

        [BsonElement(elementName: "Temp_Max")]
        internal int Temp_Max { get; set; }

        internal Main(int temp, int pressure, int humidity, int temp_min, int temp_max)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            Temp_Max = temp_max;
            Temp_Min = temp_min;
        }
    }
}
