using System;
using System.Collections.Generic;

namespace Bai4_1721030651_VuDinhLam.Models;

public partial class OrderDetail
{
    public int? Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

    public int? Status { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
