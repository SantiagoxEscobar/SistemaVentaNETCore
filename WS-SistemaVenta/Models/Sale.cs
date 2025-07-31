using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class Sale
{
    public long Id { get; set; }

    public int IdClient { get; set; }

    public int IdSaleStatus { get; set; }

    public int IdPaymentMethod { get; set; }

    public DateTime SaleDate { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string? PurchaseOrderNumber { get; set; }

    public string? Comments { get; set; }

    public DateOnly? EstimatedShippingDate { get; set; }

    public DateOnly? ActualShippingDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual PaymentMethod IdPaymentMethodNavigation { get; set; } = null!;

    public virtual SaleStatus IdSaleStatusNavigation { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual User? UpdatedByNavigation { get; set; }
}
