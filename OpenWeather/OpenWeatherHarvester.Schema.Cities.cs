using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

// ~ UNDER CONSTRUCTION, BUILDING ENUM WITH LIKE 200K CITIES ~

namespace OpenWeatherHarvester.Schema.Cities
{
    internal class OpenWeatherHarvesterCity
    {

        internal OpenWeatherHarvesterCity(City city)
        {
            switch(city)
            {
                case City.Houston_US:
                    var message = "Credit rules, CASH drools :P";
                    for(int i = 1; i < 10; i++)
                    {
                        Console.WriteLine(message + "\r\n");
                    }
                    break;
                default:
                    break;
            }
        }
    }

    internal enum City
    {
        Houston_US
    }
}
