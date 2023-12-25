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
using WPFDecstop.Models;

namespace WPFDecstop.vm
{
    /// <summary>
    /// Логика взаимодействия для SchedulingForm.xaml
    /// </summary>
    public partial class SchedulingFormOneDay : Page
    { 
        List<Models.Cabinet> CabinetList => new TimetableContext().Cabinets.ToList();


        public SchedulingFormOneDay()
        {
            InitializeComponent();
            List<Frame> pageListViewCabinet = new List<Frame>();
            foreach (var cabinet in CabinetList)
            {
                pageListViewCabinet.Add(new Frame());
                pageListViewCabinet[pageListViewCabinet.Count-1].Content = new PageListViewCabinet(cabinet.CabinetNumber);
            }
            //new List<Frame>() { new Frame(), new Frame() }
            ListViewCabinet.ItemsSource = pageListViewCabinet;
            
            
            var t = new List<Frame>() { new Frame(), new Frame() };
       
            foreach (var i in t)
            {
                i.Content = new PairEditing();
            }
            ListView1.ItemsSource =t;
        }
    }
}
