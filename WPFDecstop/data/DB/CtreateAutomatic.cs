using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using WPFDecstop.Models;

namespace WPFDecstop.data.DB;

public class CtreateAutomatic
{
    public CtreateAutomatic()
    {
        using TimetableContext db = new TimetableContext();
        if(db.Weekdays.Count()!= 6)
            CreateWeekday();
        if(db.LessonNumbers.Count()!= 7)
            CreateLessonNumber();
        if(db.Subjects.Count()!= 1)
            CreateLessonSubjects();
        if(db.Teachers.Count()!= 1)
            CreateLessonTeachers();
        if(db.Groups.Count()!= 1)
            CreateLessonGroups();
    }

    private static void CreateWeekday()
    {
        using TimetableContext db = new TimetableContext();
        var week = new Weekday[6]
        {
            new ()
            {
                Id = 0,
                Name = "Понедельник"
            },
            new ()
            {
                Id = 1,
                Name = "Вторник"
            },
            new()
            {
                Id = 2,
                Name = "Среда"
            },
            new ()
            {
                Id = 3,
                Name = "Четверг"
            },
            new ()
            {
                Id = 4,
                Name = "Пятница"
            },
            new ()
            {
                Id = 5,
                Name = "Субота"
            }
        };
        foreach (var variable in week)
        {
            db.Weekdays.Add(variable);
            db.SaveChanges();
        }
    }
    private static void CreateLessonNumber()
    {
        using TimetableContext db = new TimetableContext();
        var lessonNumber = new LessonNumber[7]
        {
            new ()
            {
                Id = 1,
                LessonNumber1 = 1
            },
            new ()
            {
                Id = 2,
                LessonNumber1 = 2
            },
            new()
            {
                Id = 3,
                LessonNumber1 = 3
            },
            new ()
            {
                Id = 4,
                LessonNumber1 = 4
            },
            new ()
            {
                Id = 5,
                LessonNumber1 = 5
            },
            new ()
            {
                Id = 6,
                LessonNumber1 = 6
            },
            new ()
            {
                Id = 7,
                LessonNumber1 = 7
            }
        };
        foreach (var variable in lessonNumber)
        {
            db.LessonNumbers.Add(variable);
            db.SaveChanges();
        }
    }
    private static void CreateLessonSubjects()
    {
        using TimetableContext db = new TimetableContext();
        db.Subjects.Add(new Subject(){});
        db.SaveChanges();
    }
    private static void CreateLessonTeachers()
    {
        using TimetableContext db = new TimetableContext();
        db.Teachers.Add(new Teacher(){});
        db.SaveChanges();
    }
    private static void CreateLessonGroups()
    {
        using TimetableContext db = new TimetableContext();
        db.Groups.Add(new Group(){});
        db.SaveChanges();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands", MessageId = "count: 756")]
    public static void CreateWeeks(int id)
    {
        using TimetableContext db = new TimetableContext();
        var t = db.Weeks.Count() + 1;
        for (int i = 0; i != 18; i++)
        {
            var r = new Week() { Id = t + i, IdSemester = id };
            db.Weeks.Add(r);
            db.SaveChanges();

            for (int y = 0; y != 6; y++)
            {
                var day = new Day { Id = db.Days.Count() + 1, IdWeek = r.Id, IdWeekday = db.Weekdays.ToList()[y].Id };
                db.Days.Add(day);
                db.SaveChanges();

                for (int e = 0; e != 7; e++)
                {
                    using TimetableContext dbf = new TimetableContext();
                    var p = new Lesson()
                    {
                         IdDay = day.Id, IdLessonNumber = e + 1,
                        IdCabinet = 1, IdGroup = 1, IdSubject = 1,
                        IdTeacher = 1
                    };
                    dbf.Lessons.Add(p);
                    dbf.SaveChanges();
                }
            }
        }
    }
    
    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records")]
    [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands", MessageId = "count: 756")]
    public static void CreatLessonCabinet()
    {
        var day = new TimetableContext().Days.ToList();
        var cabinet = new TimetableContext().Cabinets.ToList()[new TimetableContext().Cabinets.Count()-1];
        foreach (var variable in day)
        {
            for (int i = 0; i != 7; i++)
            {
                using TimetableContext db = new TimetableContext();
                   
                var p = new Lesson()
                {
                    IdDay = variable.Id, IdLessonNumber = i + 1,
                    IdCabinet = cabinet.Id, IdGroup = 1, IdSubject = 1,
                    IdTeacher = 1
                };
                db.Lessons.Add(p);
                db.SaveChanges();
            }
        }
    }
}