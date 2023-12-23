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
using WPFDecstop.Models;


namespace WPFDecstop.vm
{
    /// <summary>
    /// Логика взаимодействия для addTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Page
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void ButtonBase_AddTeacher(object sender, RoutedEventArgs e)
        {
            using (TimetableContext db = new TimetableContext())
            {
                Models.Teacher teacher = new Models.Teacher()
                {
                    Name = Name.Text, Surname = Surname.Text,
                    Patronomic = Patronomic.Text, Status = status.IsChecked
                };
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
        }
    }
}