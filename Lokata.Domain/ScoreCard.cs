using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class ScoreCard : EntityBase
{
    public int? CompetitorId { get; set; }

    public int? ApproachId { get; set; }

    public int? Score { get; set; }

    [JsonIgnore]
    public virtual Approach Approach { get; set; }

    [JsonIgnore]
    public virtual Competitor Competitor { get; set; }
}
