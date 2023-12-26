using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? SubjectName { get; set; }

    public int? SemesterNum { get; set; }

    public int? Hours { get; set; }

    public int? PracticHoursAmmount { get; set; }

    public int? LabAmount { get; set; }

    public int? Attestation { get; set; }

    public int? Consultation { get; set; }

    public int? ConsultationHoursAmmount { get; set; }

    public int? TotalHours { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public override string ToString()
    {
        if (SubjectName != null) return SubjectName;
        return"Нет предмета";
    }
}
