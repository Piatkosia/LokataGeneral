using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Umpire
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? PermissionDocumentNumber { get; set; }

    public DateOnly? PermissionDocumentDate { get; set; }

    public DateOnly? PermissionValidUntil { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
