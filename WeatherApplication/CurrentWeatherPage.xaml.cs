using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for CurrentWeatherPage.xaml
    /// </summary>
    public partial class CurrentWeatherPage : Page
    {
        private readonly string _apiData = null;
        public CurrentWeatherPage(string data)
        {
            _apiData = data;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           // string iconURL = "@\"../../icons/dunno.png\"";
           // MessageBox.Show(iconURL);
           // BitmapImage image = new BitmapImage();
           // image.UriSource = new Uri(iconURL);
           // image.BeginInit();
           // image.DecodePixelWidth = 20;
           // image.EndInit();
           //imgIcon.Source = image;

            if (_apiData == null) return;

            var darkResult = JsonConvert.DeserializeObject<GetDarkSky.RootObject>(_apiData);
            DetermineColor(Convert.ToInt32(darkResult.Currently.Temperature));
            var test = darkResult.Currently.Icon;
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
            txtDegree.Content = Convert.ToInt32(darkResult.Currently.Temperature).ToString();
            txtWeather.Content = $"{darkResult.Currently.Summary.First().ToString().ToUpper()}{darkResult.Currently.Summary.Substring(1)}";
            txtName.Content = darkResult.Currently.Cityname;
            txtWind.Content = $"{darkResult.Currently.WindSpeed} mph";
            txtClouds.Content = $"{darkResult.Currently.CloudCover * 100}%";
            txtPressure.Content = $"{Convert.ToInt32(darkResult.Currently.Pressure)} hpa";
            txtCoordinates.Content = $"Latitude: {darkResult.Latitude}      Longitude: {darkResult.Longitude}";
            txtSunrise.Content = $"{DateTime(darkResult.Daily.Data[0].SunriseTime.ToString())}"; //sunrise time output;
            txtSunset.Content = $"{DateTime(darkResult.Daily.Data[0].SunsetTime.ToString())}"; //sunet time output
            txtRain.Content = $"{darkResult.Currently.PrecipProbability * 100}%";
            
            if (darkResult.Alerts == null) return;



            //int x = 0;
            //iconURL = $"@\"../../images/{darkResult.currently.icon}.png"";                
            //imgIcon.Source = image;

            // txtMarquee.Content = darkResult.alerts[0].description;
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Tick += new EventHandler(dispatcherTimer_Tick);
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            //timer.Start();

            var count = darkResult.Alerts[0].Description.Count() * -1;
            //DoubleAnimation doubleAnimation = new DoubleAnimation();
            //doubleAnimation.From = canMain.ActualWidth;
            //doubleAnimation.To = -txtMarquee.ActualWidth + count;
            //doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //doubleAnimation.Duration = 
            //txtMarquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }

        private void txtDegree_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public string DateTime(string input)
        {
            var time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("hh:mm:ss tt");
            //return Time.AddSeconds(Convert.ToDouble(input)).ToLocalTime().ToString("yyyyMMddTHH:mm:ssZ");
        }//Converted time input and outputs to readable format.

        private void DetermineColor(int input)
        {
            var colorTest = input;
            Color colorType;
            if (colorTest <= 0)
            {
                colorType = Color.FromArgb(255, 154, 47, 176);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 1 && colorTest <= 10)
            {
                colorType = Color.FromArgb(255, 102, 63, 180);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 11 && colorTest <= 20)
            {
                colorType = Color.FromArgb(255, 64, 85, 178);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 21 && colorTest <= 30)
            {
                colorType = Color.FromArgb(255, 88, 124, 247);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 31 && colorTest <= 40)
            {
                colorType = Color.FromArgb(255, 29, 170, 241);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 41 && colorTest <= 50)
            {
                colorType = Color.FromArgb(255, 32, 188, 210);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 51 && colorTest <= 60)
            {
                colorType = Color.FromArgb(255, 21, 149, 136);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 61 && colorTest <= 70)
            {
                colorType = Color.FromArgb(255, 45, 153, 51);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 71 && colorTest <= 80)
            {
                colorType = Color.FromArgb(255, 140, 192, 81);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 81 && colorTest <= 90)
            {
                colorType = Color.FromArgb(255, 253, 193, 47);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest >= 91 && colorTest <= 100)
            {
                colorType = Color.FromArgb(255, 253, 151, 40);
                txtDegree.Foreground = new SolidColorBrush(colorType);
                return;
            }
            if (colorTest <= 100) return;
            colorType = Color.FromArgb(255, 251, 88, 47);
            txtDegree.Foreground = new SolidColorBrush(colorType);
            return;



        }//Changes color of the temperature text based on degrees. 
    }

}
