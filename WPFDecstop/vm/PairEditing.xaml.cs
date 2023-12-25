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
    private Lesson lesson { get; set; }
 
    public PairEditing(Lesson lesson)
    {
        InitializeComponent();
        this.lesson = lesson;
        ComboBox_Teacher.ItemsSource = TeachersList;
        ComboBox_Group.ItemsSource = GroupsList;
        ComboBox_Subject.ItemsSource = SubjectsList;
        var rr = TeachersList.Where(p => p.Id == lesson.IdTeacher).ToList()[0];

        int ii = 0;
        bool rt = true;
        for (int i = 0; i != TeachersList.Count - 1; i++)
        {
            if (TeachersList[i].Id == TeachersList.Where(p => p.Id == lesson.IdTeacher).ToList()[0].Id)
                rt = false;
            if (rt)
            {
                ii++;
            }
        }
        ComboBox_Teacher.SelectedIndex = ii;

        rt = true;
        ii = 0;
        for (int i = 0; i != GroupsList.Count - 1; i++)
        {
            if (GroupsList[i].Id == GroupsList.Where(p => p.Id == lesson.IdGroup).ToList()[0].Id)
                rt = false;
            if (rt)
            {
                ii++;
            }
        }
        ComboBox_Group.SelectedIndex = ii;
        
        
        rt = true;
        ii = 0;
        for (int i = 0; i != SubjectsList.Count - 1; i++)
        {
            if (SubjectsList[i].Id == SubjectsList.Where(p=> p.Id == lesson.IdSubject).ToList()[0].Id)
                rt = false;
            if (rt)
            {
                ii++;
            }
        }
        ComboBox_Subject.SelectedIndex =ii;
    }

    
    private void ComboBox_Semester_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBox_Teacher.SelectedItem != null && ComboBox_Group.SelectedItem != null && ComboBox_Subject.SelectedItem != null)
        {
            Models.Teacher teacher = (Models.Teacher)ComboBox_Teacher.SelectedItem;
            Models.Group group = (Models.Group)ComboBox_Group.SelectedItem;
            Models.Subject subject = (Models.Subject)ComboBox_Subject.SelectedItem;
            using (TimetableContext db = new TimetableContext())
            {
                 var lessonUpdate =  db.Lessons.Where(p=> p.Id == lesson.Id).ToList()[0];
                db.Lessons.Remove(db.Lessons.Where(p=> p.Id == lesson.Id).ToList()[0]);
                    db.SaveChanges();
                 lessonUpdate.IdTeacher = teacher.Id;
                 lessonUpdate.IdGroup = group.Id;
                 lessonUpdate.IdSubject = subject.Id;
                 db.Lessons.Add(lessonUpdate);
                 db.SaveChanges();
            }
        }
    }
}