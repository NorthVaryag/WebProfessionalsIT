using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Tehnology
{
    public int Id { get; set; }

    public string Tehnology1 { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
