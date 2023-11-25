using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Place
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Address { get; set; }

    public int? ShootingPlacesCount { get; set; }

    public virtual Address? AddressNavigation { get; set; }

    public virtual ICollection<Competitions> Competition1s { get; set; } = new List<Competitions>();
}
