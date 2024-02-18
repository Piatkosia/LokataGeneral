using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Competitions : EntityBase
{
    [Display(Name = "Miejsce")]
    public int? PlaceId { get; set; }

    public DateTime? Date { get; set; }

    [Display(Name = "Nazwa zawodów")]
    [Required(ErrorMessage = "Nazwa jest wymagana jest wymagana")]
    public string Name { get; set; }

    [Display(Name = "Opis")]
    public string Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();

    [JsonIgnore]
    public virtual Place Place { get; set; }
}
