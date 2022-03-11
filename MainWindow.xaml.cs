using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Pistolet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (AvtoCheckBox.IsChecked == true && TypeToplivoComboBox.SelectedIndex != -1 && IdTextBox.Text != "")
            {
                timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Вставьте пистолет");
            }
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ZapravkaAvtoProgress.Value == 100 || StatusBackComboBox.IsChecked == true)
            {
                ZapravkaAvtoProgress.Value = 100;
                StatusKolonkoComboBox.SelectedIndex = 0;
                StatusToplivoComboBox.SelectedIndex = 1;
                AvtoCheckBox.IsChecked = false;
                timer.Stop();
                MessageBox.Show("Автомобиль заправлен");
            }
            else
            {
                ZapravkaAvtoProgress.Value += 1;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StatusKolonkoComboBox.SelectedIndex = 0;
            StatusToplivoComboBox.SelectedIndex = 1;
        }

        private void AvtoCheckBox_Click(object sender, RoutedEventArgs e)
        {
           if(AvtoCheckBox.IsChecked == true)
            {
                StatusKolonkoComboBox.SelectedIndex = 1;
                StatusToplivoComboBox.SelectedIndex = 0;
            }
        }
    }
}
