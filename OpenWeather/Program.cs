/*


                                
                     _|      _|       _|_|_|_|_|    
                     _|_|  _|_|     _|          _|  
                     _|  _|  _|   _|    _|_|_|  _|  
                     _|      _|   _|  _|    _|  _|  
                     _|      _|   _|    _|_|_|_|    
                                    _|              
                                      _|_|_|_|_|_|  


*/
using csOpenWeather.Weather;
using csOpenWeather.Locations;
using System;

namespace csOpenWeather
{
    class Program
    {            
        static void Main(string[] args)
        {
            var houston_weather = WeatherHarvester.GetCurrentWeather(City.Houston_US, "your_api_key_here");
            Console.WriteLine(houston_weather.Conditions.GeneralDescription);
            Console.WriteLine(houston_weather.Conditions.DetailedDescription);
            Console.WriteLine(houston_weather.CsTimestamp.DateTime);
            Console.WriteLine("\r\nDone.\r\n");
            Console.ReadLine();
        }
    }
}
