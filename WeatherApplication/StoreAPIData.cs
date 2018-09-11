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
    public class StoreAPIData
    {
        //Unique API Key provided from OpenWeatherMap
        string apiKey = System.Environment.GetEnvironmentVariable("WEATHER_KEY");
        string darkAPI = System.Environment.GetEnvironmentVariable("DARK_KEY");
        string url = "";

        private bool validate;
        private string darkWeather;
        private string openWeather;
        public string zipInput { get; set; }
        public bool validation
        {
            get
            {
                return validate;
            }
            set
            {
                validate = value;
            }
        }
        public string _darkWeather {
            get
            {
                return darkWeather;
            }
            set
            {
                darkWeather = value;
            }
        }
        
        public string _openWeather {
            get
            {
                return openWeather;
            }
            set
            {
                openWeather = value;
            }
        }



        public void getData(string zip)
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
                    darkWeather = web.DownloadString(url);
                    //_darkWeather = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(darkWeather);

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
        

}   }
