using ModulAZS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ModulAZS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DownloadButonn_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient { Encoding = Encoding.UTF8 };
            try
            {
                var result = client.DownloadString($"http://localhost:52981/api/CarFillingStations/" + IdTextBox.Text);
                var infoStation = JsonConvert.DeserializeObject<Rootobject>(result);
                AddressTextBox.Text = infoStation.Address;
                Price92TextBox.Text = infoStation.Price92.ToString();
                Price95TextBox.Text = infoStation.Price95.ToString();
                Price98TextBox.Text = infoStation.Price98.ToString();
                PriceDisTextBox.Text = infoStation.PriceDis.ToString();

                Amount92TextBox.Text = infoStation.AmountOfFuel92.ToString();
                Amount95TextBox.Text = infoStation.AmountIfFuel95.ToString();
                Amount98TextBox.Text = infoStation.AmountIfFuel98.ToString();
                AmountDisTextBox.Text = infoStation.AmountIfFuelDis.ToString();

                InfoStation.Visibility = Visibility.Visible;
            }
            catch(WebException web)
            {
                if(web.ToString().Contains("Не найден"))
                    MessageBox.Show("Данной станции не существует!", "Ошибка № станиции", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) { 
            MessageBox.Show("Произошла какая-то беда!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void SaveInfoStationButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция будет реализованна позже", "Нет функционала", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
