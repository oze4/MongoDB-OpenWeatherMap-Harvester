using System;

namespace OpenWeatherHarvester
{

    internal class TimeConverter
    {
        internal static DateTime UtcToLocal(double utcDateTimeString)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return epoch.AddSeconds(utcDateTimeString);
        }
    }
}