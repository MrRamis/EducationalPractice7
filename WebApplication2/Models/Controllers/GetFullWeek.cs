using Microsoft.AspNetCore.Mvc;
using WPFDecstop.Models;
using System.Linq;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class GetFullWeek : ControllerBase
{
    private readonly ILogger<GetFullWeek> _logger;

    public GetFullWeek(ILogger<GetFullWeek> logger)
    {
        _logger = logger;
    }
 

    public List<Semester> SemestersList => new TimetableContext().Semesters.ToList();
    List<Cabinet> CabinetList => new TimetableContext().Cabinets.ToList();
    
    [HttpGet(Name = "GetFullWeek")]
    public IEnumerable<DataTa> Get()
    {
       List<DataTa> dataList = new List<DataTa>();
       var ttttrere = new TimetableContext().Semesters.ToList();
       var tttt = ttttrere.Where(t => t.EnenOrNot == true).ToList()[0];

       for (int rere = 0; rere < 6; rere++)
       {
           var lessonsWhe = new TimetableContext().Lessons.Where(p => p.IdDayNavigation.IdWeekNavigation
               .IdSemesterNavigation == tttt&&
           p.IdDayNavigation.IdWeekday == rere).ToList();
           for (int i = 0; i < CabinetList.Count; i++)
           {
               var tre = new DataTa();
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

               tre.cabinet = CabinetList[i].ToString();
               tre.droup1 = new TimetableContext().Groups.Where(p => p.Id == lessons1[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher1 = new TimetableContext().Teachers.Where(p => p.Id == lessons1[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.droup2 = new TimetableContext().Groups.Where(p => p.Id == lessons2[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher2 = new TimetableContext().Teachers.Where(p => p.Id == lessons2[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.droup3 = new TimetableContext().Groups.Where(p => p.Id == lessons3[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher3 = new TimetableContext().Teachers.Where(p => p.Id == lessons3[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.droup4 = new TimetableContext().Groups.Where(p => p.Id == lessons4[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher4 = new TimetableContext().Teachers.Where(p => p.Id == lessons4[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.droup5 = new TimetableContext().Groups.Where(p => p.Id == lessons5[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher5 = new TimetableContext().Teachers.Where(p => p.Id == lessons5[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.droup6 = new TimetableContext().Groups.Where(p => p.Id == lessons6[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher6 = new TimetableContext().Teachers.Where(p => p.Id == lessons6[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.droup7 = new TimetableContext().Groups.Where(p => p.Id == lessons7[0].IdGroup).ToList()[0].ToString()
                   .ToString();
               tre.teacher7 = new TimetableContext().Teachers.Where(p => p.Id == lessons7[0].IdTeacher).ToList()[0]
                   .ToString()
                   .ToString();
               tre.day = rere.ToString();
               dataList.Add(tre);
           }
       }

       return dataList.ToArray();
    }
}