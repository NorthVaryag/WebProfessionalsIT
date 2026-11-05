using System;
using System.Collections.Generic;

namespace WebProfessionalsIT.Entities;

public partial class Rating
{
    public int Id { get; set; }

    public int User { get; set; }

    public int Mark { get; set; }

    public DateOnly? Date { get; set; }

    public virtual User UserNavigation { get; set; } = null!;
}
