using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Sex : EntityBase
{
    [Display(Name = "Nazwa")]
    public string Name { get; set; }

    [Display(Name = "Startuje w kategoriach męskich")]
    public bool AsMale { get; set; }

    [Display(Name = "Startuje w kategoriach kobiecych")]
    public bool AsFemale { get; set; }

    [JsonIgnore]
    public virtual ICollection<Competitor> CompetitorList { get; set; } = new List<Competitor>();
}
