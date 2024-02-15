using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Sex : EntityBase
{
    public string Name { get; set; }

    public bool AsMale { get; set; }

    public bool AsFemale { get; set; }

    [JsonIgnore]
    public virtual ICollection<Competitor> CompetitorList { get; set; } = new List<Competitor>();
}
