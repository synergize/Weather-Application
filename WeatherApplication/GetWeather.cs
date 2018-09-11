using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public class GetWeather
    {
        // Class that is used to pull data from the OpenWeather API
        // and sets the data into variables. These must be setup 
        // in order in which they're acquired from the API. 

        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class RootObject
        {
            public Coord Coord { get; set; }
            public string @base { get; set; }
            public int Visibility { get; set; }
            public int Dt { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Cod { get; set; }
        }
    }
}
