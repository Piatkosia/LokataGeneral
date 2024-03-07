using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

/// <summary>
/// konkurencja
/// </summary>
public class Competition : EntityBase
{
    [Display(Name = "Nazwa konkurencji")]
    [Required(ErrorMessage = "Konkurencja jest wymagana")]
    public string Name { get; set; }

    //ilość serii
    [Range(1, 50)]
    [Display(Name = "Ilość serii")]
    public int? SeriesCount { get; set; }

    //ilość punktów do zdobycia w konkretnej serii
    [Range(1, 1000)]
    [Display(Name = "Maksymalna ilość punktów do zdobycia w jednej serii")]
    public int? MaxPointsPerSeries { get; set; }

    //podejścia w ramach konkurencji
    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
