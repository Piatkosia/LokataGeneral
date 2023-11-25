using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class TargetsAndCardsPhoto
{
    public int Id { get; set; }

    public int? AproachId { get; set; }

    public int? CompetitorId { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Approach? Aproach { get; set; }

    public virtual Competitor? Competitor { get; set; }
}
