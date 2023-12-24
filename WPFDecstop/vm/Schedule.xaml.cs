using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFDecstop.Models;

namespace WPFDecstop.vm;

public partial class Schedule : Page
{
    List<int> WeekList => new(){1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18};
    List<string> WeekDayList => new(){"Понедельник","Вторник","Среда","Четверг","Пятница","Суббота"};

    public List<Models.Semester> SemestersList => new TimetableContext().Semesters.ToList();


    public Schedule()
    {
        InitializeComponent();
        NameSchedule.DataContext = this;
        ComboBox_Week.ItemsSource =WeekList;
        ComboBox_Week_Day.ItemsSource = WeekDayList;
        ComboBox_Semester.ItemsSource = SemestersList;
    }

    private void ComboBox_Semester_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBox_Week.SelectedItem != null && ComboBox_Week_Day.SelectedItem != null && ComboBox_Semester.SelectedItem != null)
        {
            Models.Semester semester = (Models.Semester)ComboBox_Semester.SelectedItem;
            
            
            
            
            MessageBox.Show( semester.ToString());
        }
    }
}