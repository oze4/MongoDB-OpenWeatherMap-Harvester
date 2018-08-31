using System;

namespace OpenWeatherHarvester
{

    internal class SanitizedDateTime
    {
        internal DateTime DateTime { get; set; }

        internal SanitizedDateTime(double utcDateTimeString)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            DateTime = epoch.AddSeconds(utcDateTimeString);
        }
    }
}