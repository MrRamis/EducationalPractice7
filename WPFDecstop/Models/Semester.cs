using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Semester
{
    public int Id { get; set; }

    public string? Year { get; set; }

    public bool? EnenOrNot { get; set; }

    public virtual ICollection<Week> Weeks { get; set; } = new List<Week>();

    public override string ToString()
    {
        return Year;
    }
}
