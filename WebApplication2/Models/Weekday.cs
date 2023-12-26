using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Weekday
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Day> Days { get; set; } = new List<Day>();
}
