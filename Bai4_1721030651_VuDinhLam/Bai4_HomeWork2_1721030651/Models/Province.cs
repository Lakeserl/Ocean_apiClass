using System;
using System.Collections.Generic;

namespace Bai4_HomeWork2_1721030651.Models;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameSlug { get; set; }

    public string? ProvinceCode { get; set; }

    public decimal? AxisMeridian { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime Timer { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
public partial class ProvinceDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameSlug { get; set; }

    public string? ProvinceCode { get; set; }

    public decimal? AxisMeridian { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime Timer { get; set; }

    public int CountryId { get; set; }
}

