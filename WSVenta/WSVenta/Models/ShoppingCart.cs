using System;
using System.Collections.Generic;

namespace WSVenta.Models;

public partial class ShoppingCart
{
    public long Id { get; set; }

    public int IdClient { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}
