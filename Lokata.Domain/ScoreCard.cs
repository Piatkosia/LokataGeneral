using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class ScoreCard : EntityBase
{
    [Display(Name = "Uczestnik")]
    public int? CompetitorId { get; set; }

    [Display(Name = "Podejście")]
    public int? ApproachId { get; set; }

    [Display(Name = "Wynik")]
    public int? Score { get; set; }

    [JsonIgnore]
    public virtual Approach Approach { get; set; }

    [JsonIgnore]
    public virtual Competitor Competitor { get; set; }
}
