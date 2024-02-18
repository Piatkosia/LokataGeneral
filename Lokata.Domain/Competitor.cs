using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

/// <summary>
/// Zawodnik
/// </summary>
public class Competitor : EntityBase
{
    [Display(Name = "Data urodzenia")]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Wiek")]
    public int? Age { get; set; }

    [Display(Name = "Czy osoba jest niepełnosprawna?")]
    public bool? IsDisabledPerson { get; set; }

    [Display(Name = "Czy osoba jest profesjonalistą?")]
    public bool? Professional { get; set; }

    [Display(Name = "Płeć")]
    public int? SexId { get; set; }

    [Display(Name = "Imię (imiona) i nazwisko")]
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
