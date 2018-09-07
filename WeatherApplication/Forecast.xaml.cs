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

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for Forecast.xaml
    /// </summary>
    public partial class Forecast : Window
    {
        public Forecast()
        {
            InitializeComponent();
            
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
            DataTable dt = new DataTable();            
            dtTest.DataContext = dt;
            DataColumn colDay = new DataColumn("Day", typeof(string));
            DataColumn colLoc = new DataColumn("Location", typeof(string));
            DataColumn colTemp = new DataColumn("Temperature", typeof(string));
            DataColumn colWeatherType = new DataColumn("Weather Type", typeof(string));
            DataColumn colSpeed = new DataColumn("Wind Speed", typeof(string));
            DataColumn colClouds = new DataColumn("Cloud Coverage", typeof(string));
            DataColumn colPressure = new DataColumn("Pressure", typeof(string));
            DataColumn colSunrise = new DataColumn("Sunrise", typeof(string));
            DataColumn colSunset = new DataColumn("Sunset", typeof(string));
            DataColumn colHumidity = new DataColumn("Humidity", typeof(string));
            DataColumn colLat = new DataColumn("Latitude", typeof(string));
            DataColumn colLong = new DataColumn("Longitude", typeof(string));

            dt.Columns.Add(colDay);
            dt.Columns.Add(colLoc);
            dt.Columns.Add(colTemp);
            dt.Columns.Add(colWeatherType);
            dt.Columns.Add(colSpeed);
            dt.Columns.Add(colClouds);
            dt.Columns.Add(colPressure);
            dt.Columns.Add(colSunrise);
            dt.Columns.Add(colSunset);
            dt.Columns.Add(colHumidity);
            dt.Columns.Add(colLat);
            dt.Columns.Add(colLong);

                DataRow AddRow;
            GetForecast output = new GetForecast();
            for (int i = 0; i < 6; i++)
            {                
                AddRow = dt.NewRow();
                AddRow[colDay] = output.foreDay[i];
                AddRow[colLoc] = output.foreLoc[i];
                dt.Rows.Add(AddRow);

            }

            //DataRow windSpeed;
            //windSpeed = dt.NewRow();
            //windSpeed[colDay] = "Test";
            //windSpeed[colLoc] = "Testing";
            //DataRow firstRow = dt.NewRow();
            //firstRow[0] = "Testing";
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
