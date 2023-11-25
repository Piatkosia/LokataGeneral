using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Competition
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SeriesCount { get; set; }

    public int? MaxPointsPerSeries { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
