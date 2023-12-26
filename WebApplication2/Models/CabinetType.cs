using System;
using System.Collections.Generic;

namespace WPFDecstop.Models;

public partial class CabinetType
{
    public int Id { get; set; }

    public string? CabinetName { get; set; }

    public string? Discription { get; set; }

    public virtual ICollection<Cabinet> Cabinets { get; set; } = new List<Cabinet>();

    public override string ToString()
    {
        return CabinetName;
    }
}
