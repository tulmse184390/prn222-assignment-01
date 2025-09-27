using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Contract
{
    public int ContractId { get; set; }

    public int OrderId { get; set; }

    public DateTime? ContractDate { get; set; }

    public string? Terms { get; set; }

    public string? Status { get; set; }

    public virtual Order Order { get; set; } = null!;
}
