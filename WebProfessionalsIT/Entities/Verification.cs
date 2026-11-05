using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Verification
{
    public int Id { get; set; }

    public int UserConfirming { get; set; }

    public int UserConfirmated { get; set; }

    public DateOnly? Date { get; set; }

    public int Status { get; set; }

    public string? Description { get; set; }

    public int? UserSkills { get; set; }

    public virtual Status StatusNavigation { get; set; } = null!;

    public virtual User UserConfirmatedNavigation { get; set; } = null!;

    public virtual User UserConfirmingNavigation { get; set; } = null!;

    public virtual UserSkill? UserSkillsNavigation { get; set; }
}
