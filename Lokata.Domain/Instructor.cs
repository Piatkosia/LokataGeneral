﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Lokata.Domain.DataAnnotations;

namespace Lokata.Domain;

public class Instructor : EntityBase
{
    [Display(Name = "Imię (imiona) i nazwisko")]
    public string FullName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [Display(Name = "Uprawnienia ważne do")]
    [NotPastDate]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime? DocumentValidUntil { get; set; }

    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
