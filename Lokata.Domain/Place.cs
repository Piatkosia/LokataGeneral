namespace Lokata.Domain;

//Miejsce, w którym odbywają się zawody
public class Place : EntityBase
{
    public string Name { get; set; }

    public int? Address { get; set; }

    public int? ShootingPlacesCount { get; set; }

    public virtual Address AddressNavigation { get; set; }

    public virtual ICollection<Competitions> CompetitionsList { get; set; } = new List<Competitions>();
}
