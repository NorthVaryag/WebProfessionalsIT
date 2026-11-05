using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Experience
{
    public int Id { get; set; }

    public int? EmploymentType { get; set; }

    public string? Company { get; set; }

    public string? PositionJob { get; set; }

    public DateOnly? StartWork { get; set; }

    public DateOnly? EndWork { get; set; }

    public int User { get; set; }

    public virtual EmploymentType? EmploymentTypeNavigation { get; set; }

    public virtual User UserNavigation { get; set; } = null!;
}
