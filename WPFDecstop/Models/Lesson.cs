using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int IdDay { get; set; }

    public int IdLessonNumber { get; set; }

    public int IdCabinet { get; set; }

    public int IdGroup { get; set; }

    public int IdSubject { get; set; }

    public int IdTeacher { get; set; }

    public virtual Cabinet IdCabinetNavigation { get; set; } = null!;

    public virtual Day IdDayNavigation { get; set; } = null!;

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual LessonNumber IdLessonNumberNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
