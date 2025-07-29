using System;
using System.Collections.Generic;

namespace WSVenta.Models;

public partial class Promotion
{
    public long Id { get; set; }

    public int IdPromotionType { get; set; }

    public int IdDisplayLocation { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? TargetUrl { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual DisplayLocation IdDisplayLocationNavigation { get; set; } = null!;

    public virtual PromotionType IdPromotionTypeNavigation { get; set; } = null!;
}
