using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for Forecast.xaml
    /// </summary>
    public partial class Forecast : Window
    {
        string apiData = "";
        public Forecast(string getData)
        {
            InitializeComponent();
            apiData = getData;
            
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CreateDataTable()
        {
            var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(apiData);
            DataTable dt = new DataTable();            
            dtTest.DataContext = dt;
            //Column Headers
            DataColumn colDay = new DataColumn("Day", typeof(string));
            DataColumn colLoc = new DataColumn("Location", typeof(string));
            DataColumn colTempHigh = new DataColumn("High", typeof(string));
            DataColumn colTempLow = new DataColumn("Low", typeof(string));
            DataColumn colRain = new DataColumn("Chance of Rain", typeof(string));
            DataColumn colWeatherType = new DataColumn("Weather Type", typeof(string));
            DataColumn colSpeed = new DataColumn("Wind Speed", typeof(string));
            DataColumn colWindGust = new DataColumn("Wind Gust", typeof(string));
            DataColumn colClouds = new DataColumn("Cloud Coverage", typeof(string));
            DataColumn colPressure = new DataColumn("Pressure", typeof(string));
            DataColumn colSunrise = new DataColumn("Sunrise", typeof(string));
            DataColumn colSunset = new DataColumn("Sunset", typeof(string));            
            DataColumn colUVIndex = new DataColumn("UV Index", typeof(string));

            
            //Data Columns
            dt.Columns.Add(colDay);
            dt.Columns.Add(colLoc);
            dt.Columns.Add(colTempHigh);
            dt.Columns.Add(colTempLow);
            dt.Columns.Add(colRain);
            dt.Columns.Add(colWeatherType);
            dt.Columns.Add(colSpeed);
            dt.Columns.Add(colWindGust);
            dt.Columns.Add(colClouds);
            dt.Columns.Add(colPressure);
            dt.Columns.Add(colSunrise);
            dt.Columns.Add(colSunset);
            dt.Columns.Add(colUVIndex);

            DataRow tableDataInput;
            DateTime formatTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //Fills Daily forecast table with data
            for (int i = 0; i < darkResult.daily.data.Count; i++)
            {
                tableDataInput = dt.NewRow();
                tableDataInput[colDay] = formatTime.AddSeconds(darkResult.daily.data[i].time).DayOfWeek;
                tableDataInput[colLoc] = $"{darkResult.currently.cityname}";
                tableDataInput[colTempHigh] = $"{Convert.ToInt32(darkResult.daily.data[i].temperatureHigh)}°F";
                tableDataInput[colTempLow] = $"{Convert.ToInt32(darkResult.daily.data[i].temperatureLow)}°F";
                tableDataInput[colRain] = $"{darkResult.daily.data[i].precipProbability * 100}%";
                tableDataInput[colWeatherType] = darkResult.daily.data[i].summary;
                tableDataInput[colSpeed] = $"{darkResult.daily.data[i].windSpeed} mph";
                tableDataInput[colWindGust] = $"{darkResult.daily.data[i].windGust} mph";
                tableDataInput[colClouds] = $"{darkResult.daily.data[i].cloudCover * 100}%";
                tableDataInput[colPressure] = $"{darkResult.daily.data[i].pressure}";
                tableDataInput[colSunrise] = $"{formatTime.AddSeconds(darkResult.daily.data[i].sunriseTime).ToString("hh:mm:ss tt")}";
                tableDataInput[colSunset] = $"{formatTime.AddSeconds(darkResult.daily.data[i].sunsetTime).ToString("hh:mm:ss tt")}";
                tableDataInput[colUVIndex] = darkResult.daily.data[i].uvIndex;

                dt.Rows.Add(tableDataInput);
            }

            dtTest.ItemsSource = dt.DefaultView;

            

        }

        private void txtZip_Forecast_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void dtTest_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));
            dtTest.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));
            CreateDataTable();
        }
    }
}
