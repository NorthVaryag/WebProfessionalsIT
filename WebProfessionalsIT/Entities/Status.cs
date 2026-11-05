using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<Verification> Verifications { get; set; } = new List<Verification>();
}
