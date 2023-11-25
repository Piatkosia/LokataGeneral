using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class TargetsOrCardTake : EntityBase
{
    public int? CompetitorId { get; set; }

    public int? ApproachId { get; set; }

    public bool? CardOrTargetTaken { get; set; }

    public virtual Approach? Approach { get; set; }

    public virtual Competitor? Competitor { get; set; }
}
