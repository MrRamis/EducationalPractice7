using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
using WPFDecstop.data.captcha;

namespace WPFDecstop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GetCorginatesNumbers getCorginatesNumbers = new GetCorginatesNumbers();
        private String capt = "";
        private int countNotAttemps=0;
        public MainWindow()
        {
            InitializeComponent();
            genCapt();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            genCapt();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Text.Text == capt)
            {
                TextResult.Text = "Ok";
            }
            else
            {
                countNotAttemps++;
                if(countNotAttemps == 3)
                    Process.GetCurrentProcess().Kill();
            }
        }
        private void genCapt()
        {
            Random random = new Random();

            one.Points.Clear();
            two.Points.Clear();
            three.Points.Clear();
            four.Points.Clear();
            capt = "";
            var oneRandom = random.Next(9);
            var twoRandom = random.Next(9);
            var threeRandom = random.Next(9);
            var fourRandom = random.Next(9);
            capt += oneRandom;
            capt += twoRandom;
            capt += threeRandom;
            capt += fourRandom;
            foreach (var t in getCorginatesNumbers.getCorginatesNumbers(oneRandom))
            {
                one.Points.Add(t);
            }
            foreach (var t in getCorginatesNumbers.getCorginatesNumbers(twoRandom))
            {
                two.Points.Add(t);
            }
            foreach (var t in getCorginatesNumbers.getCorginatesNumbers(threeRandom))
            {
                three.Points.Add(t);
            }
            foreach (var t in getCorginatesNumbers.getCorginatesNumbers(fourRandom))
            {
                four.Points.Add(t);
            }
        }
    }
}