using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class TargetsAndCardsPhoto : EntityBase
{

    [Display(Name = "Podejście")]
    public int? ApproachId { get; set; }

    [Display(Name = "Zawodnik")]
    public int? CompetitorId { get; set; }

    [JsonIgnore]
    public byte[] Photo { get; set; }

    [JsonIgnore]
    public virtual Approach Approach { get; set; }

    [JsonIgnore]
    public virtual Competitor Competitor { get; set; }
}
