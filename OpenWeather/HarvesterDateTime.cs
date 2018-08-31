using System;

namespace csOpenWeather
{

    public class HarvesterDateTime
    {
        public DateTime DateTime { get; set; }

        public HarvesterDateTime() 
            : this((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds)
        {
        }

        public HarvesterDateTime(double utcDateTimeString)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            DateTime = epoch.AddSeconds(utcDateTimeString);
        }
    }
}