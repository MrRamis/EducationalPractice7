using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Spire.Xls;
using WPFDecstop.Models;

namespace WPFDecstop.vm.Report;

public partial class ReportDay : Page
{
    List<string> WeekList => new(){"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18"};
    List<string> WeekDayList => new(){"Понедельник","Вторник","Среда","Четверг","Пятница","Суббота"};

    public List<Models.Semester> SemestersList => new TimetableContext().Semesters.ToList();
    List<Models.Cabinet> CabinetList => new TimetableContext().Cabinets.ToList();
    public ReportDay()
    {
        InitializeComponent();
        ComboBox_Week.ItemsSource = WeekList;
        ComboBox_Week_Day.ItemsSource = WeekDayList;
        ComboBox_Semester.ItemsSource = SemestersList;
    }
    private void ComboBox_Semester_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBox_Week.SelectedItem != null && ComboBox_Week_Day.SelectedItem != null &&
            ComboBox_Semester.SelectedItem != null)
        {
            Models.Semester semester = (Models.Semester)ComboBox_Semester.SelectedItem;
            /*Frame.Content = new SchedulingFormOneDay(semester, 
                WeekList.IndexOf(ComboBox_Week.SelectedItem.ToString())+1,
                );#1#*/

            string[,] Massive = new string[CabinetList.Count()*2 , 8];
            
            var lessonsWhe = new TimetableContext().Lessons.Where(p => p.IdDayNavigation.IdWeekNavigation
                                                                        .IdSemesterNavigation == semester &&
                                                                    p.IdDayNavigation.IdWeekday == WeekDayList.IndexOf(ComboBox_Week_Day.SelectedItem.ToString()));
            for (int i = 0; i < CabinetList.Count*2; i+=2)
            {
                var t = new TimetableContext().Weeks.Where(p => p.IdSemester == semester.Id).ToList()[WeekList.IndexOf(ComboBox_Week.SelectedItem.ToString())+1 - 1];

                var lessons = lessonsWhe.Where(p => 
                                                                   p.IdDayNavigation.IdWeek == t.Id &&
                                                                   p.IdCabinet == CabinetList[i/2].Id
                );
                var lessons1 = lessons.Where(p => p.IdLessonNumber == 1).ToList();
                var lessons2 = lessons.Where(p => p.IdLessonNumber == 2).ToList();
                var lessons3 = lessons.Where(p => p.IdLessonNumber == 3).ToList();
                var lessons4 = lessons.Where(p => p.IdLessonNumber == 4).ToList();
                var lessons5 = lessons.Where(p => p.IdLessonNumber == 5).ToList();
                var lessons6 = lessons.Where(p => p.IdLessonNumber == 6).ToList();
                var lessons7 = lessons.Where(p => p.IdLessonNumber == 7).ToList();
                Massive[i, 0] = CabinetList[i/2].ToString();
                  Massive[i,1] = new TimetableContext().Groups.Where(p=> p.Id == lessons1[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,1] = new TimetableContext().Teachers.Where(p=> p.Id == lessons1[0].IdTeacher).ToList()[0].ToString();
                  Massive[i,2] = new TimetableContext().Groups.Where(p=> p.Id == lessons2[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,2] = new TimetableContext().Teachers.Where(p=> p.Id == lessons2[0].IdTeacher).ToList()[0].ToString();
                  Massive[i,3] = new TimetableContext().Groups.Where(p=> p.Id == lessons3[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,3] = new TimetableContext().Teachers.Where(p=> p.Id == lessons3[0].IdTeacher).ToList()[0].ToString();
                  Massive[i,4] = new TimetableContext().Groups.Where(p=> p.Id == lessons4[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,4] = new TimetableContext().Teachers.Where(p=> p.Id == lessons4[0].IdTeacher).ToList()[0].ToString();
                  Massive[i,5] = new TimetableContext().Groups.Where(p=> p.Id == lessons5[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,5] = new TimetableContext().Teachers.Where(p=> p.Id == lessons5[0].IdTeacher).ToList()[0].ToString();
                  Massive[i,6] = new TimetableContext().Groups.Where(p=> p.Id == lessons6[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,6] = new TimetableContext().Teachers.Where(p=> p.Id == lessons6[0].IdTeacher).ToList()[0].ToString();
                  Massive[i,7] = new TimetableContext().Groups.Where(p=> p.Id == lessons7[0].IdGroup).ToList()[0].ToString();
                  Massive[i+1,7] = new TimetableContext().Teachers.Where(p=> p.Id == lessons7[0].IdTeacher).ToList()[0].ToString();
            }
            
            //Создание экземпляра Workbook
            Workbook workbook = new Workbook();

            //Получение первой рабочей страницы
            Worksheet worksheet = workbook.Worksheets[0];

           
            worksheet.InsertArray(Massive, 1, 1);
            //Автоматическое подгонка ширины столбцов
            worksheet.AllocatedRange.AutoFitColumns();

            //Применение стиля к первой и третьей строке
            CellStyle style = workbook.Styles.Add("newStyle");
            style.Font.IsBold = true;
            worksheet.Range[1, 1, 1, 6].Style = style;
            worksheet.Range[3, 1, 3, 6].Style = style;

            //Сохранение в файл Excel
            workbook.SaveToFile("InsertArrays.xlsx", ExcelVersion.Version2016);
        }
    }
}