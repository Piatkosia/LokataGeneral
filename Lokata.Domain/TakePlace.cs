﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class TakePlace : EntityBase
{
    [Display(Name = "Zawodnik")]
    public int? CompetitorId { get; set; }

    [Display(Name = "Podejście")]
    public int? ApproachId { get; set; }

    [Display(Name = "Wzięcie udziału w podejściu")]
    public bool? TookPlace { get; set; }

    [JsonIgnore]
    public virtual Approach Approach { get; set; }

    [JsonIgnore]
    public virtual Competitor Competitor { get; set; }
}
