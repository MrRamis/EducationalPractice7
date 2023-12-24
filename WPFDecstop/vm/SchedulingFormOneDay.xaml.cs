using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFDecstop.vm
{
    /// <summary>
    /// Логика взаимодействия для SchedulingForm.xaml
    /// </summary>
    public partial class SchedulingFormOneDay : Page
    {
       public List<string> ere { get; set; }
        List<Day> audincese { get; set; }



        public SchedulingFormOneDay()
        {
            InitializeComponent();
            this.ere = new List<string> { "fd", "fd", "fd" };
            audincese = new List<Day>() { new Day("1", "2" ), new Day("3", "23") };
            dayDataGrid.ItemsSource = audincese;
        }
    }
   
    public class Day{
        public string audincese { get; set; }
        public string pairOne { get; set; }
        public List<string> erere { get; set; }

        public Day(string audincese, string pairOne)
        {
            this.audincese = audincese;
            this.pairOne = pairOne;
  
        }
    }
}
