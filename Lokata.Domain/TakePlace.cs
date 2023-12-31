namespace Lokata.Domain;

public class TakePlace : EntityBase
{
    public int? CompetitorId { get; set; }

    public int? ApproachId { get; set; }

    public bool? TookPlace { get; set; }

    public virtual Approach? Approach { get; set; }

    public virtual Competitor? Competitor { get; set; }
}
