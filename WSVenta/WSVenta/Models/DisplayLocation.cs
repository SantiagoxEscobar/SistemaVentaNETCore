using System;
using System.Collections.Generic;

namespace WSVenta.Models;

public partial class DisplayLocation
{
    public int Id { get; set; }

    public string LocationName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
