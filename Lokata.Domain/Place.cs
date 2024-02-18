using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

//Miejsce, w którym odbywają się zawody
public class Place : EntityBase
{
    [Display(Name = "Nazwa")]
    public string Name { get; set; }

    [Display(Name = "Adres")]
    public int? Address { get; set; }

    [Display(Name = "Ilość stanowisk strzeleckich")]
    public int? ShootingPlacesCount { get; set; }

    [JsonIgnore]
    public virtual Address AddressNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Competitions> CompetitionsList { get; set; } = new List<Competitions>();
}
