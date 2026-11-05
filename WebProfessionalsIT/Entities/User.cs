using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Surname { get; set; }

    public int? NumberPhone { get; set; }

    public string? EMail { get; set; }

    public int Role { get; set; }

    public DateOnly DateReg { get; set; }

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual UserRole RoleNavigation { get; set; } = null!;

    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();

    public virtual ICollection<Verification> VerificationUserConfirmatedNavigations { get; set; } = new List<Verification>();

    public virtual ICollection<Verification> VerificationUserConfirmingNavigations { get; set; } = new List<Verification>();
}
