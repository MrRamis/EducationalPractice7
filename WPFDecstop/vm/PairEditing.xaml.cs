using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFDecstop.Models;

namespace WPFDecstop.vm;

public partial class PairEditing : Page
{
    public List<Models.Group> GroupsList => new TimetableContext().Groups.ToList();
    public List<Models.Teacher> TeachersList => new TimetableContext().Teachers.ToList();
    public List<Models.Subject> SubjectsList => new TimetableContext().Subjects.ToList();
    public PairEditing()
    {
        InitializeComponent();
        ComboBox_Teacher.ItemsSource = TeachersList;
        ComboBox_Group.ItemsSource = GroupsList;
        ComboBox_Subject.ItemsSource = SubjectsList;
    }
    
    private void ComboBox_Semester_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBox_Teacher.SelectedItem != null && ComboBox_Group.SelectedItem != null && ComboBox_Subject.SelectedItem != null)
        {
            Models.Teacher teacher = (Models.Teacher)ComboBox_Teacher.SelectedItem;
            Models.Group group = (Models.Group)ComboBox_Group.SelectedItem;
            Models.Subject subject = (Models.Subject)ComboBox_Subject.SelectedItem;
            
            
            
            
        }
    }
}