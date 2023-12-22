using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Day
{
    public int Id { get; set; }

    public int IdWeek { get; set; }

    public int IdWeekday { get; set; }

    public DateOnly Date { get; set; }

    public virtual Week IdWeekNavigation { get; set; } = null!;

    public virtual Weekday IdWeekdayNavigation { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
