using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFDecstop.data.DB;
using WPFDecstop.Models;

namespace WPFDecstop.vm.Semester;

public partial class AddSemester : Page
{
    public AddSemester()
    {
        InitializeComponent();
    }

    private void ButtonBase_Add_Semester(object sender, RoutedEventArgs e)
    {
        int t = -5;
        using TimetableContext db = new TimetableContext();
        {
            Models.Semester semester = new Models.Semester()
            {
                Year = Year.Text
            };
            db.Semesters.Add(semester);
            db.SaveChanges();
            t = db.Semesters.ToList()[db.Semesters.Count() - 1].Id;
            CtreateAutomatic.CreateWeeks(t);
        }
        NavigationService.Navigate(null);
    }
}