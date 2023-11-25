using System;
using System.Collections.Generic;

namespace Lokata.Domain;

public class Approach : EntityBase
{
    public int? CompetitionId { get; set; }

    public int? CompetitionsId { get; set; }

    public int? InstructorId { get; set; }

    public int? UmpireId { get; set; }

    public virtual Competition Competition { get; set; }

    public virtual Competitions Competitions { get; set; }

    public virtual Instructor Instructor { get; set; }

    public virtual ICollection<ScoreCard> ScoreCards { get; set; } = new List<ScoreCard>();

    public virtual ICollection<TakePlace> TakePlaces { get; set; } = new List<TakePlace>();

    public virtual ICollection<TargetsAndCardsPhoto> TargetsAndCardsPhotos { get; set; } = new List<TargetsAndCardsPhoto>();

    public virtual ICollection<TargetsOrCardTake> TargetsOrCardTakes { get; set; } = new List<TargetsOrCardTake>();

    public virtual Umpire Umpire { get; set; }
}
