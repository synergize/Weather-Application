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
        string zipInput = "";
        //Unique API Key provided from OpenWeatherMap
        string apiKey = System.Environment.GetEnvironmentVariable("WEATHER_KEY");
        string darkAPI = System.Environment.GetEnvironmentVariable("DARK_KEY");
        string url = "";

        public bool validate { get; set; }
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
        public Image pictureTest { get; set; }

        public void getWeather(string zip)
        {


            
                using (WebClient web = new WebClient())
            {
                
                zipInput = zip;
                //Combines the zip code entered, the API key and a template for looking up via Zip code on the API. 
                url = string.Format($"http://api.openweathermap.org/data/2.5/weather?zip={zipInput},us&appid={apiKey}");

                var openWeather = Validation(url);
                

                if (validate == true)
                {
                    //Acquires the data from the URL above and stores it into json variable. 
                    
                    var result = JsonConvert.DeserializeObject<GetWeather.RootObject>(openWeather);
                    GetWeather.RootObject openOutput = result;
                    url = string.Format($"https://api.darksky.net/forecast/{darkAPI}/{openOutput.Coord.Lat},{openOutput.Coord.Lon}");
                    var darkWeather = web.DownloadString(url);
                    var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(darkWeather);

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

                }
                else
                {
                    
                }


            }
        }
        public string Validation(string json)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    //openUrl = string.Format($"http://api.openweathermap.org/data/2.5/weather?zip={zipInput},us&appid={apiKey}");
                    json = web.DownloadString(url);
                    validate = true;

                }
                return json;
            }
            catch (WebException wex)
            {
                if (wex.Source != null)
                {
                    MessageBox.Show("Please enter a valid United States Zip Code.");

                }
                validate = false;
            }
            return null;
        } //Input validation to ensure a zip code is added.

        public string DateTime(string input)
        {
            DateTime Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("hh:mm:ss tt");
        }//Converted time input and outputs to readable format.
    }
}
