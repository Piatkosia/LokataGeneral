using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class ScoreCard
{
    public int Id { get; set; }

    public int? CompetitorId { get; set; }

    public int? ApproachId { get; set; }

    public int? Score { get; set; }

    public virtual Approach? Approach { get; set; }

    public virtual Competitor? Competitor { get; set; }
}
