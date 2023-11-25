using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Address : EntityBase
{
    public string FullName { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string PostalCode { get; set; }

    public string PostalPlace { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
