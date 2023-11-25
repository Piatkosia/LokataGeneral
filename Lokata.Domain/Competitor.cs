using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public partial class Competitor
{
    public int Id { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public bool? IsDisabledPerson { get; set; }

    public bool? Proffesional { get; set; }

    public int? Sex { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<ScoreCard> ScoreCards { get; set; } = new List<ScoreCard>();

    public virtual Sex? SexNavigation { get; set; }

    public virtual ICollection<TakePlace> TakePlaces { get; set; } = new List<TakePlace>();

    public virtual ICollection<TargetsAndCardsPhoto> TargetsAndCardsPhotos { get; set; } = new List<TargetsAndCardsPhoto>();

    public virtual ICollection<TargetsOrCardTake> TargetsOrCardTakes { get; set; } = new List<TargetsOrCardTake>();
}
