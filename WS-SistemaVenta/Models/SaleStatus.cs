using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class SaleStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Sale? Sale { get; set; }
}
