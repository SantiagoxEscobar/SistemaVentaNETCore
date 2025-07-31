using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string MethodName { get; set; } = null!;

    public bool IsOnline { get; set; }

    public virtual Sale? Sale { get; set; }
}
