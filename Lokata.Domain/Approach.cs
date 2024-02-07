namespace Lokata.Domain;

/// <summary>
/// Podejście danego uczestnika do danej konkurencji na danych zawodach przy danym instruktorze i sędzi.
/// </summary>
public class Approach : EntityBase
{
    /// <summary>
    /// ID konkurencji.
    /// </summary>
    public int? CompetitionId { get; set; }

    /// <summary>
    /// ID zawodów.
    /// </summary>
    public int? CompetitionsId { get; set; }

    /// <summary>
    /// ID instruktora.
    /// </summary>

    public int? InstructorId { get; set; }

    /// <summary>
    /// ID sędziego.
    /// </summary>
    public int? UmpireId { get; set; }

    public virtual Competition Competition { get; set; }

    public virtual Competitions Competitions { get; set; }

    public virtual Instructor Instructor { get; set; }

    /// <summary>
    /// Lista wyników danego podejścia.
    /// </summary>
    public virtual ICollection<ScoreCard> ScoreCards { get; set; } = new List<ScoreCard>();

    /// <summary>
    /// Informacja o tym, że ktoś podszedł do stanowiska. Pobranie karty je tworzy i ustawia na false, wypełnienie scorecard ustawia na true.
    /// </summary>
    public virtual ICollection<TakePlace> TakePlaces { get; set; } = new List<TakePlace>();
    /// <summary>
    /// Zdjęcie tarczy lub karty - zbiór
    /// </summary>
    public virtual ICollection<TargetsAndCardsPhoto> TargetsAndCardsPhotos { get; set; } = new List<TargetsAndCardsPhoto>();

    /// <summary>
    /// Pobranie tarczy lub karty do punltów
    /// </summary>
    public virtual ICollection<TargetsOrCardTake> TargetsOrCardTakes { get; set; } = new List<TargetsOrCardTake>();

    public virtual Umpire Umpire { get; set; }
}
