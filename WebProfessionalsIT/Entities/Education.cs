using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Education
{
    public int Id { get; set; }

    public int? TypeEducations { get; set; }

    public int? InstitutionName { get; set; }

    public DateOnly? StartEducation { get; set; }

    public DateOnly? EndEducation { get; set; }

    public int? ResultEducation { get; set; }

    public int User { get; set; }

    public virtual Institution? InstitutionNameNavigation { get; set; }

    public virtual ResultEducation? ResultEducationNavigation { get; set; }

    public virtual TypeEducation? TypeEducationsNavigation { get; set; }

    public virtual User UserNavigation { get; set; } = null!;
}
