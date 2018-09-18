﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    class GetDarkSky
    {
        public class Currently
        {
            public int time { get; set; }
            public string cityname {get; set;} //Not from darksky api. Added in manually.
            public string summary { get; set; }
            public string icon { get; set; }
            public double nearestStormDistance { get; set; }
            public double nearestStormBearing { get; set; }
            public double precipIntensity { get; set; }
            public double precipProbability { get; set; }
            public double temperature { get; set; }
            public double apparentTemperature { get; set; }
            public double dewPoint { get; set; }
            public double humidity { get; set; }
            public double pressure { get; set; }
            public double windSpeed { get; set; }
            public double windGust { get; set; }
            public double windBearing { get; set; }
            public double cloudCover { get; set; }
            public int uvIndex { get; set; }
            public double visibility { get; set; }
            public double ozone { get; set; }
        }

        public class Datum
        {
            public int time { get; set; }
            public double precipIntensity { get; set; }
            public double precipProbability { get; set; }
        }

        public class Minutely
        {
            public string summary { get; set; }
            public string icon { get; set; }
            public List<Datum> data { get; set; }
        }

        public class Datum2
        {
            public int time { get; set; }
            public string summary { get; set; }
            public string icon { get; set; }
            public double precipIntensity { get; set; }
            public double precipProbability { get; set; }
            public double temperature { get; set; }
            public double apparentTemperature { get; set; }
            public double dewPoint { get; set; }
            public double humidity { get; set; }
            public double pressure { get; set; }
            public double windSpeed { get; set; }
            public double windGust { get; set; }
            public double windBearing { get; set; }
            public double cloudCover { get; set; }
            public int uvIndex { get; set; }
            public double visibility { get; set; }
            public double ozone { get; set; }
            public string precipType { get; set; }
        }

        public class Hourly
        {
            public string summary { get; set; }
            public string icon { get; set; }
            public List<Datum2> data { get; set; }
        }

        public class Datum3
        {
            public int time { get; set; }
            public string summary { get; set; }
            public string icon { get; set; }
            public int sunriseTime { get; set; }
            public int sunsetTime { get; set; }
            public double moonPhase { get; set; }
            public double precipIntensity { get; set; }
            public double precipIntensityMax { get; set; }
            public double precipIntensityMaxTime { get; set; }
            public double precipProbability { get; set; }
            public string precipType { get; set; }
            public double temperatureHigh { get; set; }
            public int temperatureHighTime { get; set; }
            public double temperatureLow { get; set; }
            public int temperatureLowTime { get; set; }
            public double apparentTemperatureHigh { get; set; }
            public int apparentTemperatureHighTime { get; set; }
            public double apparentTemperatureLow { get; set; }
            public int apparentTemperatureLowTime { get; set; }
            public double dewPoint { get; set; }
            public double humidity { get; set; }
            public double pressure { get; set; }
            public double windSpeed { get; set; }
            public double windGust { get; set; }
            public int windGustTime { get; set; }
            public int windBearing { get; set; }
            public double cloudCover { get; set; }
            public int uvIndex { get; set; }
            public int uvIndexTime { get; set; }
            public double visibility { get; set; }
            public double ozone { get; set; }
            public double temperatureMin { get; set; }
            public int temperatureMinTime { get; set; }
            public double temperatureMax { get; set; }
            public int temperatureMaxTime { get; set; }
            public double apparentTemperatureMin { get; set; }
            public int apparentTemperatureMinTime { get; set; }
            public double apparentTemperatureMax { get; set; }
            public int apparentTemperatureMaxTime { get; set; }
        }

        public class Daily
        {
            public string summary { get; set; }
            public string icon { get; set; }
            public List<Datum3> data { get; set; }
        }
        public class Alert
        {
            public string title { get; set; }
            public List<string> regions { get; set; }
            public string severity { get; set; }
            public int time { get; set; }
            public int expires { get; set; }
            public string description { get; set; }
            public string uri { get; set; }
        }

        public class Flags
        {
            public List<string> sources { get; set; }
            //public double nearest-station { get; set; }
            public string units { get; set; }
        }

        public class RootObject
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string timezone { get; set; }
            public Currently currently { get; set; }
            public Minutely minutely { get; set; }
            public Hourly hourly { get; set; }
            public Daily daily { get; set; }
            public List<Alert> alerts { get; set; }
            public Flags flags { get; set; }
            public int offset { get; set; }
        }
    }
}
