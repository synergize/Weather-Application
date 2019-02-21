using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private string _apiData = null;
        private bool _isNumber = false;
        public RefactorMainPage()
        {
            InitializeComponent();
        }

        private void btnCurrent_Click(object sender, RoutedEventArgs e)
        {
            txtDescription.Visibility = Visibility.Hidden;
         //   _isNumber = int.TryParse(txtZip.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _zipInput);
            if (Validation(txtZip.Text) == true)
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
         //   _isNumber = int.TryParse(txtZip.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _zipInput);
            _apiData = Validation(txtZip.Text) == true ? acquireData.GetWeather(txtZip.Text) : null; // Checks _apiData if it's number by attempting to parse it via _isNumber. If it's true, we pull API data based on the zip code. If it's not, we set _apiData to null
                                                                                                     // Null prevents inaccurate zip code entries after the first.
            if (_apiData == null)
            {
                return;
            }
            Main.Content = new CurrentWeatherPage(_apiData);
            txtDescription.Visibility = Visibility.Hidden;
            btnCurrent.IsEnabled = true;
            btnForecast.IsEnabled = true;
        }

        private bool Validation(string zip)
        {
            bool _isNumber = false;
            int _zipInput;
            var test = new CurrentWeatherPage();

            _isNumber = int.TryParse(txtZip.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _zipInput);
            if (_isNumber == true && zip.Length == 5)
            {
                return true;
            }
            else if (_isNumber == true && zip.Length != 5)
            {
                test.ShowHideObjects(Visibility.Hidden);
                    MessageBox.Show(
                        "Zip code is shorter than 5 digits. Please enter a valid 5 digit United States Zip Code.");
                    return false;
            }
            else
            {
                test.ShowHideObjects(Visibility.Hidden);
                MessageBox.Show("Zip code isn't numerical. Please enter a valid 5 digit United States Zip code.");
                return false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        } //Ensures safe close when pressing the "X". 
    }
}
