using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class LessonNumber
{
    public int Id { get; set; }

    public int? LessonNumber1 { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
