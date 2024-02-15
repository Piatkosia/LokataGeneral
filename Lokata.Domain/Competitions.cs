using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Competitions : EntityBase
{
    public int? PlaceId { get; set; }

    public DateTime? Date { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();

    [JsonIgnore]
    public virtual Place Place { get; set; }
}
