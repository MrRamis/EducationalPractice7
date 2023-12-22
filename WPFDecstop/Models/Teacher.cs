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
}
