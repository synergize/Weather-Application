using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WeatherApplication
{
    public partial class MainWindow : Window
    {
        GetData acquireData = new GetData();
        string apiData = null;
        public MainWindow()
        {

            InitializeComponent();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            string zipInput = txtZip.Text;
            apiData = acquireData.getWeather(zipInput);
            if (apiData != null)
            {
                var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(apiData);
                DetermineColor(Convert.ToInt32(darkResult.currently.temperature));
                txtName.Visibility = Visibility.Visible;
                txtDegree.Visibility = Visibility.Visible;
                txtWeather.Visibility = Visibility.Visible;
                txtClouds.Visibility = Visibility.Visible;
                txtWind.Visibility = Visibility.Visible;
                txtPressure.Visibility = Visibility.Visible;
                txtCoordinates.Visibility = Visibility.Visible;
                txtSunrise.Visibility = Visibility.Visible;
                txtSunset.Visibility = Visibility.Visible;
                txtHumidity.Visibility = Visibility.Visible;
                txtDegree.Content = Convert.ToInt32(darkResult.currently.temperature).ToString();
                txtWeather.Content = $"{darkResult.currently.summary.First().ToString().ToUpper()}{darkResult.currently.summary.Substring(1)}";
                txtName.Content = darkResult.timezone;
                txtWind.Content = $"{darkResult.currently.windSpeed} mph";
                txtClouds.Content = $"{darkResult.currently.cloudCover * 100}%";
                txtPressure.Content = $"{Convert.ToInt32(darkResult.currently.pressure)} hpa";
                txtCoordinates.Content = $"Latitude: {darkResult.latitude}      Longitude: {darkResult.longitude}";
                txtSunrise.Content = $"{DateTime(darkResult.daily.data[0].sunriseTime.ToString())}"; //sunrise time output;
                txtSunset.Content = $"{DateTime(darkResult.daily.data[0].sunsetTime.ToString())}"; //sunet time output
                txtHumidity.Content = $"{darkResult.currently.humidity * 100}%";
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        } //Ensures safe close when pressing the "X". 
        private void DetermineColor(int input)
        {
            int colorTest = input;
            Color ColorType = Color.FromArgb(0, 0, 0, 0);
            if (colorTest <= 0)
            {
                ColorType = Color.FromArgb(255, 154, 47, 176);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 1 && colorTest <= 10)
            {
                ColorType = Color.FromArgb(255, 102, 63, 180);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 11 && colorTest <= 20)
            {
                ColorType = Color.FromArgb(255, 64, 85, 178);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 21 && colorTest <= 30)
            {
                ColorType = Color.FromArgb(255, 88, 124, 247);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 31 && colorTest <= 40)
            {
                ColorType = Color.FromArgb(255, 29, 170, 241);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 41 && colorTest <= 50)
            {
                ColorType = Color.FromArgb(255, 32, 188, 210);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 51 && colorTest <= 60)
            {
                ColorType = Color.FromArgb(255, 21, 149, 136);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 61 && colorTest <= 70)
            {
                ColorType = Color.FromArgb(255, 45, 153, 51);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 71 && colorTest <= 80)
            {
                ColorType = Color.FromArgb(255, 140, 192, 81);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 81 && colorTest <= 90)
            {
                ColorType = Color.FromArgb(255, 253, 193, 47);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest >= 91 && colorTest <= 100)
            {
                ColorType = Color.FromArgb(255, 253, 151, 40);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }
            if (colorTest > 100)
            {
                ColorType = Color.FromArgb(255, 251, 88, 47);
                txtDegree.Foreground = new SolidColorBrush(ColorType);
                return;
            }



        }//Changes color of the temperature text based on degrees. 

        private void txtDegree_Loaded(object sender, RoutedEventArgs e)
        {
            txtDegree.Content = "Enter a zip code to check the weather!";
            txtDegree.Visibility = Visibility.Visible;
            txtDegree.Foreground = new SolidColorBrush(Color.FromArgb(255, 31, 181, 238));
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));
        }//Visual modifications for labels when loading the program.
        private void DetermineBackground()
        {
            //if (.weatherOut.Contains("rain"))
            //{
            //    this.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));

            //}
        } //Currently unused and inprogress.

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //About Menu Button
            MessageBox.Show("Greetings! This is my first application making use of an API called OpenWeatherMap. It can be located here, https://openweathermap.org/.", "About This Weather Application");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            //Forecast Menu Button
            if (apiData != null)
            {
                Forecast forecastWindow = new Forecast(apiData);
                forecastWindow.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show($"Please enter a Zip Code Below and Press \"Enter\"");
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //Exit Application Menu Button
            Application.Current.Shutdown();
        }
        public string DateTime(string input)
        {
            DateTime Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("hh:mm:ss tt");
            //return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("yyyyMMddTHH:mm:ssZ");
        }//Converted time input and outputs to readable format.
    }
}
