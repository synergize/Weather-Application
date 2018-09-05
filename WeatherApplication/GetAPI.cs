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
                    
                    //var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<GetWeather.RootObject>(openWeather);
                    GetWeather.RootObject openOutput = result;
                    url = string.Format($"https://api.darksky.net/forecast/{darkAPI}/{openOutput.Coord.Lat},{openOutput.Coord.Lon}");
                    var darkWeather = web.DownloadString(url);
                    var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(darkWeather);


                    // ConvertDegrees Convert = new ConvertDegrees();
                    // temperatureOut = Convert.convertFahrenheit(openOutput.Main.Temp).ToString();
                    // weatherOut = openOutput.Weather[0].Description;
                    // nameOut = openOutput.Name;
                    // windOut = $"Speed: {openOutput.Wind.Speed} m/h";
                    // cloudsOut = openOutput.Clouds.All.ToString();
                    // pressureOut = $"{openOutput.Main.Pressure.ToString()} hpa";
                    // humidOut = $"{openOutput.Main.Humidity.ToString()}%";
                    // var sunrise = openOutput.Sys.Sunrise;
                    // var sunset = openOutput.Sys.Sunset;
                    //// sunriseOut = DateTime(output.Sys.Sunrise.ToString());
                    //// sunsetOut = DateTime(output.Sys.Sunset.ToString());
                    // coordsOut = $"Latitude: {openOutput.Coord.Lat} Longitude: {openOutput.Coord.Lon}";

                    //ConvertDegrees Convert = new ConvertDegrees();
                    temperatureOut = Convert.ToInt32(darkResult.currently.temperature).ToString(); 
                    weatherOut = darkResult.currently.summary;
                    nameOut = darkResult.timezone;
                    windOut = $"Speed: {darkResult.currently.windSpeed} m/h";
                    cloudsOut = darkResult.currently.cloudCover.ToString();
                    pressureOut = $"{darkResult.currently.pressure.ToString()} hpa";
                    humidOut = $"{darkResult.currently.humidity.ToString()}%";
                    var sunrise = openOutput.Sys.Sunrise;
                    var sunset = openOutput.Sys.Sunset;
                    // sunriseOut = DateTime(output.Sys.Sunrise.ToString());
                    // sunsetOut = DateTime(output.Sys.Sunset.ToString());
                    coordsOut = $"Latitude: {openOutput.Coord.Lat} Longitude: {openOutput.Coord.Lon}";

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
            input = TimeSpan.FromSeconds(Convert.ToDouble(input)).ToString();
            DateTime Time = new DateTime(Convert.ToInt64(input));
            var output = Time.ToShortTimeString();
            return output;
        }//Converted time input and outputs to readable format.
    }
}
