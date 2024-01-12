
using Microsoft.AspNetCore.Mvc;
using WPFDecstop.Models;
using System.Linq;
using WebApplication2.Properties;


namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class GetFul : ControllerBase
{
    private readonly ILogger<GetFul> _logger;

    public GetFul(ILogger<GetFul> logger)
    {
        _logger = logger;
    }
 

    public List<Semester> SemestersList => new TimetableContext().Semesters.ToList();
    List<Cabinet> CabinetList => new TimetableContext().Cabinets.ToList();
    
    [HttpGet(Name = "GetFul")]
    public IEnumerable<Datata> Get()
    {
       List<Datata> dataList = new List<Datata>();
       var ttttrere = new TimetableContext().Semesters.ToList();
       var tttt = ttttrere.Where(t => t.EnenOrNot == true).ToList()[0];

       for (int rere = 0; rere < 6; rere++)
       {
           var lessonsWhe = new TimetableContext().Lessons.Where(p => p.IdDayNavigation.IdWeekNavigation
               .IdSemesterNavigation == tttt&&
           p.IdDayNavigation.IdWeekday == rere).ToList();
           for (int i = 0; i < CabinetList.Count; i++)
           {
               var tre = new Datata();
               var re = new TimetableContext().Semesters.Where(t => t.EnenOrNot == true).ToArray()[0];
               var t = new TimetableContext().Weeks.Where(p => p.IdSemester == re.Id).ToArray()[0];


               var lessons = new TimetableContext().Lessons.Where(p => p.IdDayNavigation.IdWeekNavigation
                                                                           .IdSemesterNavigation == tttt &&
                                                                       p.IdDayNavigation.IdWeekday == rere&&
                                                                       p.IdDayNavigation.IdWeek == t.Id &&
                                                                       p.IdCabinet == CabinetList[i].Id
               ).ToList();
               var lessons1 = lessons.Where(p => p.IdLessonNumber == 1).ToList();
               var lessons2 = lessons.Where(p => p.IdLessonNumber == 2).ToList();
               var lessons3 = lessons.Where(p => p.IdLessonNumber == 3).ToList();
               var lessons4 = lessons.Where(p => p.IdLessonNumber == 4).ToList();
               var lessons5 = lessons.Where(p => p.IdLessonNumber == 5).ToList();
               var lessons6 = lessons.Where(p => p.IdLessonNumber == 6).ToList();
               var lessons7 = lessons.Where(p => p.IdLessonNumber == 7).ToList();

               var cabinet = CabinetList[i].ToString();
               var droup1 = new TimetableContext().Groups.Where(p => p.Id == lessons1[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher1 = new TimetableContext().Teachers.Where(p => p.Id == lessons1[0].IdTeacher).ToList()[0]
                   .ToString();

               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher1, droup = droup1, day = rere.ToString() , pair = "1"});

                   var droup2 = new TimetableContext().Groups.Where(p => p.Id == lessons2[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher2 = new TimetableContext().Teachers.Where(p => p.Id == lessons2[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher2, droup = droup2, day = rere.ToString(), pair = "2" });
               var droup3 = new TimetableContext().Groups.Where(p => p.Id == lessons3[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher3 = new TimetableContext().Teachers.Where(p => p.Id == lessons3[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               
               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher3, droup = droup3, day = rere.ToString() , pair = "3"});
               var droup4 = new TimetableContext().Groups.Where(p => p.Id == lessons4[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher4 = new TimetableContext().Teachers.Where(p => p.Id == lessons4[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               
               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher4, droup = droup4, day = rere.ToString() , pair = "4"});
               var droup5 = new TimetableContext().Groups.Where(p => p.Id == lessons5[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher5 = new TimetableContext().Teachers.Where(p => p.Id == lessons5[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               
               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher5, droup = droup5, day = rere.ToString() , pair = "5"});
               var droup6 = new TimetableContext().Groups.Where(p => p.Id == lessons6[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher6 = new TimetableContext().Teachers.Where(p => p.Id == lessons6[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher6, droup = droup6, day = rere.ToString() , pair = "6"});
               var droup7 = new TimetableContext().Groups.Where(p => p.Id == lessons7[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               var teacher7 = new TimetableContext().Teachers.Where(p => p.Id == lessons7[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               dataList.Add(new Datata()
                   { cabinet = cabinet, teacher = teacher7, droup = droup7, day = rere.ToString() , pair = "7"});
           }
       }
       return dataList.ToArray();
    }
}