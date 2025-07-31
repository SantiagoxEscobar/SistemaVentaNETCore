using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class SaleDetail
{
    public long Id { get; set; }

    public long IdSale { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPriceAtSale { get; set; }

    public decimal LineDiscountAmount { get; set; }

    public decimal LineTaxAmount { get; set; }

    public decimal LineTotalAmount { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Sale IdSaleNavigation { get; set; } = null!;
}
