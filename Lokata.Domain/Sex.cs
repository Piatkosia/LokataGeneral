using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Sex
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? AsMale { get; set; }

    public bool? AsFemale { get; set; }

    public virtual ICollection<Competitor> Competitors { get; set; } = new List<Competitor>();
}
