namespace Lokata.Domain;

public class Instructor : EntityBase
{
    public string FullName { get; set; }

    public List<Document> Documents { get; set; } = new();

    public DateTime? DocumentValidUntil { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
