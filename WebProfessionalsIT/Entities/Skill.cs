using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Skill
{
    public int Id { get; set; }

    public int Tehnology { get; set; }

    public int Level { get; set; }

    public virtual LevelSkill LevelNavigation { get; set; } = null!;

    public virtual Tehnology TehnologyNavigation { get; set; } = null!;

    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
