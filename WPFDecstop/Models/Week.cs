using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Week
{
    public int Id { get; set; }

    public int? IdSemester { get; set; }

    public virtual ICollection<Day> Days { get; set; } = new List<Day>();

    public virtual Semester? IdSemesterNavigation { get; set; }
}
