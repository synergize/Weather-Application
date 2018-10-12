using System.Collections.Generic;

namespace WeatherApplication
{
    class GetDarkSky
    {
        public class Currently
        {
            public int Time { get; set; }
            public string Cityname {get; set;} //Not from darksky api. Added in manually.
            public string Summary { get; set; }
            public string Icon { get; set; }
            public double NearestStormDistance { get; set; }
            public double NearestStormBearing { get; set; }
            public double PrecipIntensity { get; set; }
            public double PrecipProbability { get; set; }
            public double Temperature { get; set; }
            public double ApparentTemperature { get; set; }
            public double DewPoint { get; set; }
            public double Humidity { get; set; }
            public double Pressure { get; set; }
            public double WindSpeed { get; set; }
            public double WindGust { get; set; }
            public double WindBearing { get; set; }
            public double CloudCover { get; set; }
            public int UvIndex { get; set; }
            public double Visibility { get; set; }
            public double Ozone { get; set; }
        }

        public class Datum
        {
            public int Time { get; set; }
            public double PrecipIntensity { get; set; }
            public double PrecipProbability { get; set; }
        }

        public class Minutely
        {
            public string Summary { get; set; }
            public string Icon { get; set; }
            public List<Datum> Data { get; set; }
        }

        public class Datum2
        {
            public int Time { get; set; }
            public string Summary { get; set; }
            public string Icon { get; set; }
            public double PrecipIntensity { get; set; }
            public double PrecipProbability { get; set; }
            public double Temperature { get; set; }
            public double ApparentTemperature { get; set; }
            public double DewPoint { get; set; }
            public double Humidity { get; set; }
            public double Pressure { get; set; }
            public double WindSpeed { get; set; }
            public double WindGust { get; set; }
            public double WindBearing { get; set; }
            public double CloudCover { get; set; }
            public int UvIndex { get; set; }
            public double Visibility { get; set; }
            public double Ozone { get; set; }
            public string PrecipType { get; set; }
        }

        public class Hourly
        {
            public string Summary { get; set; }
            public string Icon { get; set; }
            public List<Datum2> Data { get; set; }
        }

        public class Datum3
        {
            public int Time { get; set; }
            public string Summary { get; set; }
            public string Icon { get; set; }
            public int SunriseTime { get; set; }
            public int SunsetTime { get; set; }
            public double MoonPhase { get; set; }
            public double PrecipIntensity { get; set; }
            public double PrecipIntensityMax { get; set; }
            public double PrecipIntensityMaxTime { get; set; }
            public double PrecipProbability { get; set; }
            public string PrecipType { get; set; }
            public double TemperatureHigh { get; set; }
            public int TemperatureHighTime { get; set; }
            public double TemperatureLow { get; set; }
            public int TemperatureLowTime { get; set; }
            public double ApparentTemperatureHigh { get; set; }
            public int ApparentTemperatureHighTime { get; set; }
            public double ApparentTemperatureLow { get; set; }
            public int ApparentTemperatureLowTime { get; set; }
            public double DewPoint { get; set; }
            public double Humidity { get; set; }
            public double Pressure { get; set; }
            public double WindSpeed { get; set; }
            public double WindGust { get; set; }
            public int WindGustTime { get; set; }
            public int WindBearing { get; set; }
            public double CloudCover { get; set; }
            public int UvIndex { get; set; }
            public int UvIndexTime { get; set; }
            public double Visibility { get; set; }
            public double Ozone { get; set; }
            public double TemperatureMin { get; set; }
            public int TemperatureMinTime { get; set; }
            public double TemperatureMax { get; set; }
            public int TemperatureMaxTime { get; set; }
            public double ApparentTemperatureMin { get; set; }
            public int ApparentTemperatureMinTime { get; set; }
            public double ApparentTemperatureMax { get; set; }
            public int ApparentTemperatureMaxTime { get; set; }
        }

        public class Daily
        {
            public string Summary { get; set; }
            public string Icon { get; set; }
            public List<Datum3> Data { get; set; }
        }
        public class Alert
        {
            public string Title { get; set; }
            public List<string> Regions { get; set; }
            public string Severity { get; set; }
            public int Time { get; set; }
            public int Expires { get; set; }
            public string Description { get; set; }
            public string Uri { get; set; }
        }

        public class Flags
        {
            public List<string> Sources { get; set; }
            //public double nearest-station { get; set; }
            public string Units { get; set; }
        }

        public class RootObject
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Timezone { get; set; }
            public Currently Currently { get; set; }
            public Minutely Minutely { get; set; }
            public Hourly Hourly { get; set; }
            public Daily Daily { get; set; }
            public List<Alert> Alerts { get; set; }
            public Flags Flags { get; set; }
            public int Offset { get; set; }
        }
    }
}
