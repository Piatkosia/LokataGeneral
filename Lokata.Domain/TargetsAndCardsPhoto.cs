using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class TargetsAndCardsPhoto : EntityBase
{
    public int? ApproachId { get; set; }

    public int? CompetitorId { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Approach Approach { get; set; }

    public virtual Competitor Competitor { get; set; }
}
