using Newtonsoft.Json;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for WeeklyForecastPage.xaml
    /// </summary>
    public partial class WeeklyForecastPage : Page
    {
        private readonly string _apiData = null;

        public WeeklyForecastPage()
        {
        }

        public WeeklyForecastPage(string data)
        {
            _apiData = data;
            InitializeComponent();
        }

        private void CreateDataTable()
        {
            if (_apiData == null) return;
            var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(_apiData);
            var dt = new DataTable();
            dtTest.DataContext = dt;
            //Column Headers
            DataColumn colDay = new DataColumn("Day", typeof(string));
            DataColumn colLoc = new DataColumn("Location", typeof(string));
            DataColumn colTempHigh = new DataColumn("High", typeof(string));
            DataColumn colTempLow = new DataColumn("Low", typeof(string));
            DataColumn colRain = new DataColumn("Chance of Rain", typeof(string));
            DataColumn colWeatherType = new DataColumn("Weather Type", typeof(string));
            DataColumn colClouds = new DataColumn("Cloud Coverage", typeof(string));
            DataColumn colUvIndex = new DataColumn("UV Index", typeof(string));


            //Data Columns
            dt.Columns.Add(colDay);
            dt.Columns.Add(colLoc);
            dt.Columns.Add(colTempHigh);
            dt.Columns.Add(colTempLow);
            dt.Columns.Add(colRain);
            dt.Columns.Add(colWeatherType);
            dt.Columns.Add(colClouds);
            dt.Columns.Add(colUvIndex);

            var formatTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //Fills Daily forecast table with data
            foreach (var r in darkResult.Daily.Data)
            {
                var tableDataInput = dt.NewRow();
                tableDataInput[colDay] = formatTime.AddSeconds(r.Time).DayOfWeek;
                tableDataInput[colLoc] = $"{darkResult.Currently.Cityname}";
                tableDataInput[colTempHigh] = $"{Convert.ToInt32(r.TemperatureHigh)}°F";
                tableDataInput[colTempLow] = $"{Convert.ToInt32(r.TemperatureLow)}°F";
                tableDataInput[colRain] = $"{r.PrecipProbability * 100}%";
                tableDataInput[colWeatherType] = r.Summary;
                tableDataInput[colClouds] = $"{r.CloudCover * 100}%";
                tableDataInput[colUvIndex] = r.UvIndex;

                dt.Rows.Add(tableDataInput);
            }
            dtTest.ItemsSource = dt.DefaultView;
            //dtTest.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));


        }

        private void dtTest_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void WeeklyForecastPage_Loaded(object sender, RoutedEventArgs e)
        {
            CreateDataTable();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));
        }

        private void dtTest_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
