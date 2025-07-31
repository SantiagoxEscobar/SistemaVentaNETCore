using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class Client
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneCode { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentNumber { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<ClientCard> ClientCards { get; set; } = new List<ClientCard>();

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual Sale? Sale { get; set; }

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
