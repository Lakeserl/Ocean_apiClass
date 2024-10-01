using System;
using System.Collections.Generic;

namespace Bai4_HomeWork2_1721030651.Models;

public partial class BankType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime Timer { get; set; }

    public virtual ICollection<Bank> Banks { get; set; } = new List<Bank>();
}


public partial class BankTypeDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime Timer { get; set; }
}
