using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for RefactorMainPage.xaml
    /// </summary>
    public partial class RefactorMainPage : Window
    {
        private int _zipInput;
        private string _apiData = null;
        private bool _isNumber = false;
        public RefactorMainPage()
        {
            InitializeComponent();
        }

        private void btnCurrent_Click(object sender, RoutedEventArgs e)
        {
            txtDescription.Visibility = Visibility.Hidden;
            _isNumber = int.TryParse(txtZip.Text, out _zipInput);
            if (_isNumber == true)
            Main.Content = new CurrentWeatherPage(_apiData);
        }

        private void btnForecast_Click(object sender, RoutedEventArgs e)
        {
            txtDescription.Visibility = Visibility.Hidden;
            Main.Content = new WeeklyForecastPage(_apiData);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"../../images/lightrain.gif", UriKind.Relative)));
            txtDescription.Content = "Enter a Zip Code and Press \"Update Zip\"!";
            txtDescription.Foreground = new SolidColorBrush(Color.FromArgb(255, 31, 181, 238));
            btnCurrent.IsEnabled = false;
            btnForecast.IsEnabled = false;
        }

        private void btnZip_Click(object sender, RoutedEventArgs e)
        {            
            var acquireData = new GetData();
            _isNumber = int.TryParse(txtZip.Text, out _zipInput);
            if (_isNumber == true)
                 _apiData = acquireData.GetWeather(_zipInput.ToString());
            if (_apiData == null)
            {
                MessageBox.Show("Please enter a valid United States Zip Code.");
                return;
            }
            Main.Content = new CurrentWeatherPage(_apiData);
            txtDescription.Visibility = Visibility.Hidden;
            btnCurrent.IsEnabled = true;
            btnForecast.IsEnabled = true;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        } //Ensures safe close when pressing the "X". 
    }
}
