using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class TakePlace : EntityBase
{
    public int? CompetitorId { get; set; }

    public int? ApproachId { get; set; }

    public bool? TookPlace { get; set; }

    [JsonIgnore]
    public virtual Approach Approach { get; set; }

    [JsonIgnore]
    public virtual Competitor Competitor { get; set; }
}
