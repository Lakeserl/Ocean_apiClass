﻿using System;
using System.Collections.Generic;

namespace Bai4_1721030651_VuDinhLam.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string WardCode { get; set; } = null!;

    public int DistrictId { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
