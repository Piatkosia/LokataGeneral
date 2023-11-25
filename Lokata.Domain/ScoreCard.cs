using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class ScoreCard : EntityBase
{
    public int? CompetitorId { get; set; }

    public int? ApproachId { get; set; }

    public int? Score { get; set; }

    public virtual Approach Approach { get; set; }

    public virtual Competitor Competitor { get; set; }
}
