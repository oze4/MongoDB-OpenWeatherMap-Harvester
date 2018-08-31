using System;

namespace csOpenWeather
{

    internal class HarvesterDateTime
    {
        internal DateTime DateTime { get; set; }

        internal HarvesterDateTime() 
            : this((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds)
        {
        }

        internal HarvesterDateTime(double utcDateTimeString)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            DateTime = epoch.AddSeconds(utcDateTimeString);
        }
    }
}