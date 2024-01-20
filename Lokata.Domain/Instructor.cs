namespace Lokata.Domain;

public class Instructor : EntityBase
{
    public string FullName { get; set; }

    public int? DocumentId { get; set; }

    public Document Document { get; set; }

    public DateOnly? DocumentValidUntil { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
