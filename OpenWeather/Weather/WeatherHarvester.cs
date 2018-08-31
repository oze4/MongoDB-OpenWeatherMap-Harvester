/*


                                
                     _|      _|       _|_|_|_|_|    
                     _|_|  _|_|     _|          _|  
                     _|  _|  _|   _|    _|_|_|  _|  
                     _|      _|   _|  _|    _|  _|  
                     _|      _|   _|    _|_|_|_|    
                                    _|              
                                      _|_|_|_|_|_|  


*/
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using csOpenWeather.Locations;
using csOpenWeather.Weather;

namespace csOpenWeather
{
    internal class WeatherHarvester
    {
        internal static CurrentWeather GetCurrentWeather(City city, string apiToken)
        {
            var url = string.Format(
                "http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=imperial", (int)city, apiToken
                );
            var webreq = WebRequest.Create(url);
            var webResponse = webreq.GetResponse();
            var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(resp);

            var _weatherid = json["weather"][0]["id"].Value<string>();
            var _internaltimestamp = new HarvesterDateTime(); // returns now as utc double
            var _city = json["name"].Value<string>();
            var _code = json["cod"].Value<int>();
            var _visibility = json["visibility"].Value<int>();

            var _weathercalculationtime = new HarvesterDateTime(
                json["dt"].Value<double>()
                );
            var _sunrise = new HarvesterDateTime(
                json["sys"]["sunrise"].Value<double>()
                );
            var _sunset = new HarvesterDateTime(
                json["sys"]["sunset"].Value<double>()
                );
            var _coords = new Coordinate(
                json["coord"]["lon"].Value<int>(), 
                json["coord"]["lat"].Value<int>()
                );
            var _iconcode = json["weather"][0]["icon"].Value<string>();
            var _conditions = new Conditions(
                json["weather"][0]["id"].Value<string>(),
                json["weather"][0]["main"].Value<string>(),
                json["weather"][0]["description"].Value<string>(),
                string.Format("https://openweathermap.org/img/{0}.png", _iconcode) // set icon url
                );
            var _climate = new Climate(
                json["main"]["temp"].Value<float>(),
                json["main"]["pressure"].Value<float>(),
                json["main"]["humidity"].Value<float>(),
                json["main"]["temp_min"].Value<float>(),
                json["main"]["temp_max"].Value<float>()
                );
            var _wind = new Wind(
                json["wind"]["speed"].Value<float>(),
                json["wind"]["deg"].Value<float>()
                );
            var _clouds = new Clouds(
                json["clouds"]["all"].Value<int>()
                );

            return new CurrentWeather(
                _internaltimestamp, 
                _weatherid, 
                _city, 
                _code, 
                _visibility, 
                _weathercalculationtime, 
                _sunrise, 
                _sunset,
                _coords, 
                _conditions, 
                _climate, 
                _wind, 
                _clouds
                );
        }
    }
}
