using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Group
{
    public int Id { get; set; }

    public string? GroupNumber { get; set; }

    public string? ShortNumber { get; set; }

    public int? StudentAmmount { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
