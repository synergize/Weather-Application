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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            string Degree = "0°";
            string Weather = "null";
        public MainWindow()
        {
            InitializeComponent();
            txtDegree.Content = Degree;
            txtWeather.Content = Weather;

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            string zipInput = "92618";
            GetAPI testing = new GetAPI();
            testing.getWeather(zipInput);
            txtDegree.Content = testing.temperatureOut;
            txtWeather.Content = testing.weatherOut;
            
            
        }
    }
}
