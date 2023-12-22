using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class Cabinet
{
    public int Id { get; set; }

    public int? IdCabinetType { get; set; }

    public int? AmmountOfPlaces { get; set; }

    public string? CabinetNumber { get; set; }

    public virtual CabinetType? IdCabinetTypeNavigation { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
