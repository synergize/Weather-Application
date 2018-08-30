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
        string apiKey = "445ddb6bf3e34f9c627843a0d7fc99dd";
        string url = "";
        bool validate = false;
        public string temperatureOut { get; set; }
        public string weatherOut { get; set; }
        public string nameOut { get; set; }

        public void getWeather(string zip)
        {


            //using (StreamReader web = File.OpenText(@"C:\Users\vtrinks\Documents\apiTest.json"));
                using (WebClient web = new WebClient())
            {
                
                zipInput = zip;
                //Combines the zip code entered, the API key and a template for looking up via Zip code on the API. 
                url = string.Format($"http://api.openweathermap.org/data/2.5/weather?zip={zipInput},us&appid={apiKey}");

                Validation(url);

                if (validate == true)
                {

                    //Acquires the data from the URL above and stores it into json variable. 
                    var json = web.DownloadString(url);


                  //  var result = JsonConvert.DeserializeObject<GetWeather.RootObject>(File.ReadAllText(@"C:\Users\vtrinks\Documents\apiTest.json"));
                    //Breaks down the data from json and splits it into variables located in the GetWeather Class.
                    var result = JsonConvert.DeserializeObject<GetWeather.RootObject>(json);
                    //Takes the data from the RootObject class and provides it into a useable variable for manipulation or output.
                    GetWeather.RootObject output = result;

                
                    ConvertDegrees Convert = new ConvertDegrees();
                    temperatureOut = Convert.convertFahrenheit(output.Main.Temp).ToString();
                    weatherOut = output.Weather[0].Description;
                    nameOut = output.Name;
                }
                else
                {
                    
                }


            }
        }
        public bool Validation(string json)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    //url = string.Format($"http://api.openweathermap.org/data/2.5/weather?zip={zipInput},us&appid={apiKey}");
                    //json = web.DownloadString(url);
                    //File.WriteAllText(@"C:\Users\vtrinks\Documents\apiTest.json", JsonConvert.SerializeObject(json));

                }
                return validate = true;
            }
            catch (WebException wex)
            {
                if (wex.Source != null)
                {
                    MessageBox.Show("Please enter a valid United States Zip Code.");
                }
                return validate = false;
            }
        } //Input validation to ensure a zip code is added.
    }
}
