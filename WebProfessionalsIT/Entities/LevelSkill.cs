using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class LevelSkill
{
    public int Id { get; set; }

    public string Level { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
