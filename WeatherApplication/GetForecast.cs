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
    class GetForecast
    {
        
        public string[] foreDay = new string[7];
        public string[] foreLoc = new string[7];
        public int[] foreTemp = new int[7];
        public string[] foreWeather = new string[7];
        public double[] foreWind = new double[7];
        public int[] foreClouds = new int[7];
        public int[] forePressure = new int[7];
        public string[] foreSunrise = new string[7];
        public string[] foreSunset = new string[7];
        public int[] foreHumidity = new int[7];
        public string[] foreLat = new string[7];
        public string[] foreLong = new string[7];   

        public void populateArrays()
        {
            GetAPI forecastData = new GetAPI();
            for (int i = 0; i < foreDay.Length; i++)
            {
                //foreDay[i] = forecastData
            }
        }

    }

        

    
}
