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
using System.Windows.Shapes;

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for RefactorMainPage.xaml
    /// </summary>
    public partial class RefactorMainPage : Window
    {
        int zipInput;
        string apiData = null;
        bool isNumber = false;
        public RefactorMainPage()
        {
            InitializeComponent();
        }

        private void btnCurrent_Click(object sender, RoutedEventArgs e)
        {
            txtDescription.Visibility = Visibility.Hidden;
            isNumber = int.TryParse(txtZip.Text, out zipInput);
            if (isNumber == true)
            Main.Content = new CurrentWeatherPage(apiData);
        }

        private void btnForecast_Click(object sender, RoutedEventArgs e)
        {
            txtDescription.Visibility = Visibility.Hidden;
            Main.Content = new WeeklyForecastPage(apiData);
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
            GetData acquireData = new GetData();
            isNumber = int.TryParse(txtZip.Text, out zipInput);
            if (isNumber == true)
                 apiData = acquireData.getWeather(zipInput.ToString());
            if (apiData != null)
            {
                Main.Content = new CurrentWeatherPage(apiData);
                txtDescription.Visibility = Visibility.Hidden;
                btnCurrent.IsEnabled = true;
                btnForecast.IsEnabled = true;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        } //Ensures safe close when pressing the "X". 
    }
}
