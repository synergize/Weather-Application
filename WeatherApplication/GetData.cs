using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherApplication
{
    internal class GetData
    {
        private string _zipInput = "";
        //Unique API Key provided from OpenWeatherMap
        private readonly string _apiKey = System.Environment.GetEnvironmentVariable("WEATHER_KEY");
        private readonly string _darkApi = System.Environment.GetEnvironmentVariable("DARK_KEY");
        private string _url = "";
        private string _openWeather = null;
        private string _darkWeather = null;
        public bool Validate { get; set; }

        public string GetWeather(string zip)
        {            
                using (var web = new WebClient())
            {                
                _zipInput = zip;
                //Combines the zip code entered, the API key and a template for looking up via Zip code on the API. 
                _url = string.Format($"http://api.openweathermap.org/data/2.5/weather?zip={_zipInput},us&appid={_apiKey}");

                _openWeather = Validation(_url);
                

                if (Validate == true)
                {
                    //Acquires the data from the URL above and stores it into json variable.                     
                    var result = JsonConvert.DeserializeObject<GetWeather.RootObject>(_openWeather);
                    var openOutput = result;
                    _url = string.Format($"https://api.darksky.net/forecast/{_darkApi}/{openOutput.Coord.Lat},{openOutput.Coord.Lon}");                    
                    _darkWeather = web.DownloadString(_url);
                    //Using JObject class to append JSON data and inject the city name into DarkSky API Output.
                    var testObject = JObject.Parse(_darkWeather);
                    var cityName = (JObject)testObject["currently"];
                    cityName.Property("time").AddAfterSelf(new JProperty("cityname", CityName(openOutput)));
                    return _darkWeather = testObject.ToString();


                }
                else
                {
                    return null;
                }
            }
        }
        public string Validation(string json)
        {
            try
            {
                using (var web = new WebClient())
                {
                    json = web.DownloadString(_url);
                    Validate = true;

                }
                return json;
            }
            catch (WebException wex)
            {
                if (wex.Source != null)
                {
                    MessageBox.Show("Please enter a valid United States Zip Code.");

                }
                Validate = false;
            }
            return null;
        } //Input validation to ensure a zip code is added.

        public string DateTime(string input)
        {
            var time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);

            return time.AddSeconds(Convert.ToDouble(input)).ToString("hh:mm:ss tt");
            //return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("yyyyMMddTHH:mm:ssZ");
        }//Converted time input and outputs to readable format.
        public string CityName(GetWeather.RootObject input)
        {
            return input.Name;
        }//Return City Name
    }
}
