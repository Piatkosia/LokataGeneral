namespace Lokata.Domain;

public class Umpire : EntityBase
{
    public string FullName { get; set; }

    public string PermissionDocumentNumber { get; set; }

    public DateTime? PermissionDocumentDate { get; set; }

    public DateTime? PermissionValidUntil { get; set; }

    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
