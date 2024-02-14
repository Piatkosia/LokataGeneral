namespace Lokata.Domain;

/// <summary>
/// konkurencja
/// </summary>
public class Competition : EntityBase
{
    public string Name { get; set; }

    //ilość serii
    public int? SeriesCount { get; set; }

    //ilość punktów do zdobycia w konkretnej serii
    public int? MaxPointsPerSeries { get; set; }

    //podejścia w ramach konkurencji
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
