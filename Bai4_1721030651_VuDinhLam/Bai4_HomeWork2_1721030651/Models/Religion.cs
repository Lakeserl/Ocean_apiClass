using System;
using System.Collections.Generic;

namespace Bai4_HomeWork2_1721030651.Models;

public partial class Religion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameSlug { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime Timer { get; set; }
}


public partial class ReligionDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameSlug { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime Timer { get; set; }
}

