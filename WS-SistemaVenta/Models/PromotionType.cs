using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class PromotionType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
