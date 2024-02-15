using System.Text.Json.Serialization;

namespace Lokata.Domain;

/// <summary>
/// Zawodnik
/// </summary>
public class Competitor : EntityBase
{
    public DateTime? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public bool? IsDisabledPerson { get; set; }

    public bool? Professional { get; set; }

    public int? SexId { get; set; }

    public string FullName { get; set; }

    [JsonIgnore]
    public virtual ICollection<ScoreCard> ScoreCards { get; set; } = new List<ScoreCard>();

    [JsonIgnore]
    public virtual Sex Sex { get; set; }

    [JsonIgnore]
    public virtual ICollection<TakePlace> TakePlaces { get; set; } = new List<TakePlace>();

    [JsonIgnore]
    public virtual ICollection<TargetsAndCardsPhoto> TargetsAndCardsPhotos { get; set; } = new List<TargetsAndCardsPhoto>();

    [JsonIgnore]
    public virtual ICollection<TargetsOrCardTake> TargetsOrCardTakes { get; set; } = new List<TargetsOrCardTake>();
}
