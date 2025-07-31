using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class Address
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public string AddressStreet { get; set; } = null!;

    public string AddressNumber { get; set; } = null!;

    public string? AddressFloor { get; set; }

    public string City { get; set; } = null!;

    public string StateProvince { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;
}
