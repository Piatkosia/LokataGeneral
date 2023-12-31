namespace Lokata.Domain;

public class Umpire : EntityBase
{
    public string FullName { get; set; }

    public string PermissionDocumentNumber { get; set; }

    public DateOnly? PermissionDocumentDate { get; set; }

    public DateOnly? PermissionValidUntil { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
