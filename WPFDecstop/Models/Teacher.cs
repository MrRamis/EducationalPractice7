using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Patronomic { get; set; }

    public string? Name { get; set; }

    public Boolean? Status { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public override string? ToString()
    {
        if (Name != null)
            if (Patronomic != null)
                return Surname + Name[0] + Patronomic[0];
        if (Name != null) return Surname + Name[0];
        if (Surname != null)return Surname;
        return"Нет преподователя";
    }
}
