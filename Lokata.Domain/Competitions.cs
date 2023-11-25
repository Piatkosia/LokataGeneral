using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Competitions : EntityBase
{
    public int? PlaceId { get; set; }

    public DateOnly? Date { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();

    public virtual Place Place { get; set; }
}
