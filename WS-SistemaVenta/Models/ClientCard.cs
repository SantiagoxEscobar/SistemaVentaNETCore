using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class ClientCard
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public string CardToken { get; set; } = null!;

    public string? LastFourDigits { get; set; }

    public string? CardType { get; set; }

    public int ExpirationMonth { get; set; }

    public int ExpirationYear { get; set; }

    public string CardholderName { get; set; } = null!;

    public bool IsDefault { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;
}
