using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WeatherApplication
{
    class GetAPI
    {
        //Unique API Key provided from OpenWeatherMap
        string apiKey = System.Environment.GetEnvironmentVariable("WEATHER_KEY");
        string darkAPI = System.Environment.GetEnvironmentVariable("DARK_KEY");
        bool verify = false;
        string url = "";

       // public bool validate { get; set; }
        public string temperatureOut { get; set; }
        public string weatherOut { get; set; }
        public string nameOut { get; set; }
        public string windOut { get; set; }
        public string cloudsOut { get; set; }
        public string pressureOut { get; set; }
        public string humidOut { get; set; }
        public string sunriseOut { get; set; }
        public string sunsetOut { get; set; }
        public string coordsOut { get; set; }

        public void getWeather()
        {
            //using (WebClient web = new WebClient())
            //{                
            //zipInput = zip;
            //Combines the zip code entered, the API key and a template for looking up via Zip code on the API. 
            //url = string.Format($"http://api.openweathermap.org/data/2.5/weather?zip={zipInput},us&appid={apiKey}");

            //var openWeather = Validation(url);
            
            StoreAPIData darkAPIData = new StoreAPIData();           
                if (darkAPIData.validation == true)                
                {
                    //Acquires the data from the URL above and stores it into json variable. 
                    
                    //var result = JsonConvert.DeserializeObject<GetWeather.RootObject>(openWeather);
                    //GetWeather.RootObject openOutput = result;
                   // url = string.Format($"https://api.darksky.net/forecast/{darkAPI}/{openOutput.Coord.Lat},{openOutput.Coord.Lon}");
                   // var darkWeather = web.DownloadString(url);
                    var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(darkAPIData._darkWeather);
                    var openOutput = JsonConvert.DeserializeObject<GetWeather.RootObject>(darkAPIData._openWeather);


                temperatureOut = Convert.ToInt32(darkResult.currently.temperature).ToString(); 
                    weatherOut = darkResult.currently.summary;
                    nameOut = darkResult.timezone;
                    windOut = $"{darkResult.currently.windSpeed} mph";
                    cloudsOut = $"{darkResult.currently.cloudCover * 100}%";
                    pressureOut = $"{Convert.ToInt32(darkResult.currently.pressure)} hpa";
                    humidOut = $"{darkResult.currently.humidity * 100}%";
                    sunriseOut = $"{DateTime(darkResult.daily.data[0].sunriseTime.ToString())}"; //sunrise time output
                    sunsetOut = $"{DateTime(darkResult.daily.data[0].sunsetTime.ToString())}"; //sunet time output
                    coordsOut = $"Latitude: {openOutput.Coord.Lat}      Longitude: {openOutput.Coord.Lon}";
                    PassForecast(darkResult);
                }
                else
                {
                    
                }
            //}
        }

        
        public void PassForecast(GetDarkSky.RootObject rootObject)
        {
            GetForecast update = new GetForecast();
            for (int i = 1; i < rootObject.daily.data.Count - 1; i++)
            {
                DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                update.foreDay[i] = day.AddSeconds(Convert.ToDouble(rootObject.daily.data[i].time)).DayOfWeek.ToString();
                update.foreLoc[i] = rootObject.timezone;
            }

        }

        public string DateTime(string input)
        {
            DateTime Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("hh:mm:ss tt");
            //return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("yyyyMMddTHH:mm:ssZ");
        }//Converted time input and outputs to readable format.

    }
}
