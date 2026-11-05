using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class UserSkill
{
    public int Id { get; set; }

    public int User { get; set; }

    public int? Skill { get; set; }

    public virtual Skill? SkillNavigation { get; set; }

    public virtual User UserNavigation { get; set; } = null!;

    public virtual ICollection<Verification> Verifications { get; set; } = new List<Verification>();
}
