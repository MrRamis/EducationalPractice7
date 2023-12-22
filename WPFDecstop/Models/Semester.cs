using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Semester
{
    public int Id { get; set; }

    public int? Year { get; set; }

    public sbyte? EnenOrNot { get; set; }

    public virtual ICollection<Week> Weeks { get; set; } = new List<Week>();
}
