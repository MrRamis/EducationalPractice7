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
    public partial class SchedulingFormOneDay : Page
    { 
        List<Models.Cabinet> CabinetList => new TimetableContext().Cabinets.ToList();
        public SchedulingFormOneDay(Models.Semester semester, int week, int day)
        {
            InitializeComponent();
            List<Frame> pageListViewCabinet = new List<Frame>();
            List<Frame> pagePairEditing1 = new List<Frame>();
            List<Frame> pagePairEditing2 = new List<Frame>();
            List<Frame> pagePairEditing3 = new List<Frame>();
            List<Frame> pagePairEditing4 = new List<Frame>();
            List<Frame> pagePairEditing5 = new List<Frame>();
            List<Frame> pagePairEditing6 = new List<Frame>();
            List<Frame> pagePairEditing7 = new List<Frame>();
            foreach (var cabinet in CabinetList)
            {
                pageListViewCabinet.Add(new Frame());
                pageListViewCabinet[pageListViewCabinet.Count - 1].Content =
                    new PageListViewCabinet(cabinet.CabinetNumber);
                var t = new TimetableContext().Weeks.Where(p => p.IdSemester == semester.Id).ToList()[week - 1];

                var lessons1 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 1 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );
                foreach (var variable in lessons1)
                {
                    pagePairEditing1.Add(new Frame());
                    pagePairEditing1[pagePairEditing1.Count - 1].Content = new PairEditing(variable);
                }

                var lessons2 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 2 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );
                foreach (var variable in lessons2)
                {
                    pagePairEditing2.Add(new Frame());
                    pagePairEditing2[pagePairEditing2.Count - 1].Content = new PairEditing(variable);
                }

                var lessons3 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 3 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );
                foreach (var variable in lessons3)
                {
                    pagePairEditing3.Add(new Frame());
                    pagePairEditing3[pagePairEditing3.Count - 1].Content = new PairEditing(variable);
                }

                var lessons4 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 4 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );

                foreach (var variable in lessons4)
                {
                    pagePairEditing4.Add(new Frame());
                    pagePairEditing4[pagePairEditing4.Count - 1].Content = new PairEditing(variable);
                }

                var lessons5 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 5 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );
                foreach (var variable in lessons5)
                {
                    pagePairEditing5.Add(new Frame());
                    pagePairEditing5[pagePairEditing5.Count - 1].Content = new PairEditing(variable);
                }

                var lessons6 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 6 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );
                foreach (var variable in lessons6)
                {
                    pagePairEditing6.Add(new Frame());
                    pagePairEditing6[pagePairEditing6.Count - 1].Content = new PairEditing(variable);
                }

                var lessons7 = new TimetableContext().Lessons.Where(p => p.IdLessonNumber == 7 &&
                                                                         p.IdDayNavigation.IdWeekNavigation
                                                                             .IdSemesterNavigation == semester &&
                                                                         p.IdDayNavigation.IdWeekday == day &&
                                                                         p.IdDayNavigation.IdWeek == t.Id &&
                                                                         p.IdCabinet == cabinet.Id
                );
                foreach (var variable in lessons7)
                {
                    pagePairEditing7.Add(new Frame());
                    pagePairEditing7[pagePairEditing7.Count - 1].Content = new PairEditing(variable);
                }
            }

            ListViewCabinet.ItemsSource = pageListViewCabinet;
            ListView1.ItemsSource = pagePairEditing1;
            ListView2.ItemsSource = pagePairEditing2;
            ListView3.ItemsSource = pagePairEditing3;
            ListView4.ItemsSource = pagePairEditing4;
            ListView5.ItemsSource = pagePairEditing5;
            ListView6.ItemsSource = pagePairEditing6;
            ListView7.ItemsSource = pagePairEditing7;
        }
    }
}
