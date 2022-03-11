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
using System.Windows.Threading;

namespace TransportModel
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

            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void CountToplivoSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            if (int.TryParse(VolumeBackTextBlox.Text, out int value))
            {
                CountToplivoSlider.Maximum = value;
                var z = (int)CountToplivoSlider.Value;

                CountToplivoTextBlox.Text = z.ToString();
                ZapravkaProgress.Value = z;
                ZapravkaProgress.Maximum = value;
            }
            else
                MessageBox.Show("Введите объем бака");
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ZapravkaProgress.Value == ZapravkaProgress.Maximum)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                MessageBox.Show("Заправка завершена");
                ZapravkaProgress.Value -= 0.1;
            }
            else
            {
                ZapravkaProgress.Value += 0.6;
                CountToplivoTextBlox.Text = ZapravkaProgress.Value.ToString();
                CountToplivoSlider.Value = ZapravkaProgress.Value;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CountToplivoSlider.Maximum = 100;
        }

        private void StartToplivoButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Tick += new EventHandler(Timer_Tick);
            if (CountToplivoTextBlox.Text != "")
                timer.Start();
        }

        private void StopToplivoButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            MessageBox.Show("Заправка завершена");
        }
    }
}
