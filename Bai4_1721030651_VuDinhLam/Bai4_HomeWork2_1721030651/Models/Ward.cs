using System;
using System.Collections.Generic;

namespace Bai4_HomeWork2_1721030651.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameSlug { get; set; }

    public string? WardCode { get; set; }

    public int DistrictId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime Timer { get; set; }

    public virtual District District { get; set; } = null!;
}


public partial class WardDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameSlug { get; set; }

    public string? WardCode { get; set; }

    public int DistrictId { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime Timer { get; set; }
}
