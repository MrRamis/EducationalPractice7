using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using WPFDecstop.Models;

namespace WPFDecstop.data.DB;

public class CtreateAutomatic
{
    public CtreateAutomatic()
    {
        using (TimetableContext db = new TimetableContext())
        {
            if(db.Weekdays.Count()!= 6)
                CreateWeekday();
            
            
            
        }
    }

    private static void CreateWeekday()
    {
        using (TimetableContext db = new TimetableContext())
        {
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
    }

    public static void CreateWeeks(int id)
    {
        using (TimetableContext db = new TimetableContext())
        {
            var t = db.Weeks.Count()+1;
            for (int i = 0; i != 18; i++)
            {
                var r = new Week() { Id = t + i, IdSemester = id };
                db.Weeks.Add(r);
                db.SaveChanges();

                for (int y = 0; y != 6; y++)
                {
                    var d = new Day() {Id = db.Days.Count()+1, IdWeek = r.Id, IdWeekday  = db.Weekdays.ToList()[y].Id};
                    db.Days.Add(d);
                    db.SaveChanges();
                }
            }
        }
    }
}