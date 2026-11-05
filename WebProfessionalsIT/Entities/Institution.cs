using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Institution
{
    public int Id { get; set; }

    public string InstitutionName { get; set; } = null!;

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
