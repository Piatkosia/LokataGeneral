using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Instructor : EntityBase
{
    public string FullName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public DateTime? DocumentValidUntil { get; set; }

    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
