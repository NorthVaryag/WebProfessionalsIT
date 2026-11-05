using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class EmploymentType
{
    public int Id { get; set; }

    public string NameType { get; set; } = null!;

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}
