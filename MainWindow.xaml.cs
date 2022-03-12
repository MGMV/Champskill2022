using ModulZapravka.Models;
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

namespace ModulZapravka
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

        private void BeginJobButton_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            var result = client.DownloadString($"http://localhost:52981/api/CarFillingStations/" + IdStationTextBox.Text);
            var infoStation = JsonConvert.DeserializeObject<GetStation>(result);
            var fuelCombo = new List<string> { infoStation.FuelT92.ToString(),
                infoStation.Fuel95.ToString() ,
                infoStation.Fuel98.ToString(),
                infoStation.FuelDis.ToString()

            };
            FuelComboBox.Items.Clear();
            FuelComboBox.ItemsSource = fuelCombo;

            var rejimCombo = new List<string> { "Фиксированный объем", "Фиксированная цена", "До полного бака" };
            RejimZapravkiComboBox.Items.Clear();
            RejimZapravkiComboBox.ItemsSource = rejimCombo;

            var oplataCombo = new List<string> { "Накопительной картой", "Банковской картой", "Кредитной картой"};
            OplataComboBox.Items.Clear();
            OplataComboBox.ItemsSource = oplataCombo;


        }

        private void OplataButton_Click(object sender, RoutedEventArgs e)
        {
            if (RejimZapravkiComboBox.SelectedIndex == -1 && FuelComboBox.SelectedIndex == -1 && OplataComboBox.SelectedIndex == -1) {
                MessageBox.Show("Заполните все поля1!");
                return;
            }
            if(NumberCardTextBox.Text == null)
            {
                MessageBox.Show("Заполните все поля2!");
                return;
            }
            if(UserCardTextBox.Text == null)
            {
                MessageBox.Show("Заполните все поля3!");
                return;
            }

            if(NumberCardTextBox.Text.Length < 19)
            {
                MessageBox.Show("Некоректная карта!");
                return;
            }
            
            if(!UserCardTextBox.Text.Contains(" "))
            {
                MessageBox.Show("Некоректное имя!");
                return;
            }

            MessageBox.Show("Не реализованно");

        }
    }
}
