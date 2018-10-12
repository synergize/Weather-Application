using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    class ConvertDegrees
    {
        public double ConvertFahrenheit(double input)
        {
            return Convert.ToInt32(input * (9d / 5d) - 459.67);
        }
        public double ConvertCelsius(double input)
        {
            return Convert.ToInt32(input - 273.15);
        }
    }
}
