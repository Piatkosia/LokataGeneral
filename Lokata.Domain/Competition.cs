using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Competition : EntityBase
{
    public string Name { get; set; }

    public int? SeriesCount { get; set; }

    public int? MaxPointsPerSeries { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
