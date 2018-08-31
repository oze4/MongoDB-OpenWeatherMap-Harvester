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
        //TODO: 
            // THIS IS UNDER CONSTRUCTION AS WELL... //        
            
        static void Main(string[] args)
        {
            var houston_weather = WeatherHarvester.GetCurrentWeather(City.Houston_US, "9d6e842241161dffa8f9963157efeded");
            Console.WriteLine(houston_weather.Conditions.GeneralDescription);
            Console.WriteLine("\r\nDone.\r\n");
            Console.ReadLine();
        }
    }
}
