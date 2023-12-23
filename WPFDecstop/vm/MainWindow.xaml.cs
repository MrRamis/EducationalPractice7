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
using WPFDecstop.vm;
using WPFDecstop.vm.Cabinet;
using WPFDecstop.vm.Group;
using WPFDecstop.vm.Item;
using WPFDecstop.vm.Teacher;
using WPFDecstop.vm.TypCabinet;

namespace WPFDecstop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        
        private void Button_Click_Page_Add_Group(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new AddGroup();
        }
        private void Button_Click_Page_Update_Group(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new UpdateGroup();
        }
        private void Button_Click_Page_Add_Teacher(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new AddTeacher();
        }
        private void Button_Click_Page_Update_Teacher(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new UpdateTeacher();
        }
        private void Button_Click_Page_Add_Cabinet(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new AddCabinet();
        }
        private void Button_Click_Page_Update_Cabinet(object sender, RoutedEventArgs e)
        {
            PageMain.Content =  new UpdateCabinet();
        }
        private void Button_Click_Page_Add_TypCabinet(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new AddTypCabinet();
        }
        private void Button_Click_Page_Update_TypCabinet(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new UpdateTypCabinet();
        }
        private void Button_Click_Page_Add_Item(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new AddSubject();
        }
        private void Button_Click_Page_Update_Item(object sender, RoutedEventArgs e)
        {
            PageMain.Content = new UpdateSubject();
        }
    }
}