using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Instructor
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public int? DocumentId { get; set; }

    public DateOnly? DocumentValidUntil { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
