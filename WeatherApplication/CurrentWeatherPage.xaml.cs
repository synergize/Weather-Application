using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for CurrentWeatherPage.xaml
    /// </summary>
    public partial class CurrentWeatherPage : Page
    {
        GetData acquireData = new GetData();
        string apiData = null;
        public CurrentWeatherPage(string data)
        {
            apiData = data;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //apiData = acquireData.getWeather(zipInput.ToString());
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
                txtRain.Visibility = Visibility.Visible;
                txtDegree.Content = Convert.ToInt32(darkResult.currently.temperature).ToString();
                txtWeather.Content = $"{darkResult.currently.summary.First().ToString().ToUpper()}{darkResult.currently.summary.Substring(1)}";
                txtName.Content = darkResult.currently.cityname;
                txtWind.Content = $"{darkResult.currently.windSpeed} mph";
                txtClouds.Content = $"{darkResult.currently.cloudCover * 100}%";
                txtPressure.Content = $"{Convert.ToInt32(darkResult.currently.pressure)} hpa";
                txtCoordinates.Content = $"Latitude: {darkResult.latitude}      Longitude: {darkResult.longitude}";
                txtSunrise.Content = $"{DateTime(darkResult.daily.data[0].sunriseTime.ToString())}"; //sunrise time output;
                txtSunset.Content = $"{DateTime(darkResult.daily.data[0].sunsetTime.ToString())}"; //sunet time output
                txtRain.Content = $"{darkResult.currently.precipProbability * 100}%";
                // txtMarquee.Content = darkResult.alerts[0].description;
                //DispatcherTimer timer = new DispatcherTimer();
                //timer.Tick += new EventHandler(dispatcherTimer_Tick);
                //timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
                //timer.Start();

                //var count = darkResult.alerts[0].description.Count() * -1;
                //DoubleAnimation doubleAnimation = new DoubleAnimation();
                //doubleAnimation.From = canMain.ActualWidth;
                //doubleAnimation.To = -txtMarquee.ActualWidth + count;
                //doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
                //doubleAnimation.Duration = 
                //txtMarquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            }
        }

        private void txtDegree_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public string DateTime(string input)
        {
            DateTime Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("hh:mm:ss tt");
            //return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("yyyyMMddTHH:mm:ssZ");
        }//Converted time input and outputs to readable format.

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
    }
}
