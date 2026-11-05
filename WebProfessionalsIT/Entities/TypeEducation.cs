using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class TypeEducation
{
    public int Id { get; set; }

    public string NameType { get; set; } = null!;

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
