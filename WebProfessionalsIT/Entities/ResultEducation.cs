using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class ResultEducation
{
    public int Id { get; set; }

    public string? Result { get; set; }

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
