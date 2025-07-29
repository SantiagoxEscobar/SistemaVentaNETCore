using System;
using System.Collections.Generic;

namespace WSVenta.Models;

public partial class ShoppingCartItem
{
    public long Id { get; set; }

    public long IdCart { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public DateTime AddedAt { get; set; }

    public virtual ShoppingCart IdCartNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
