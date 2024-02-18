using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Umpire : EntityBase
{
    [Display(Name = "Imię i nazwisko")]
    public string FullName { get; set; }

    [Display(Name = "Dokument potwierdzający uprawnienia")]
    public string PermissionDocumentNumber { get; set; }

    [Display(Name = "Data wydania uprawnień")]
    public DateTime? PermissionDocumentDate { get; set; }

    [Display(Name = "Data ważności uprawnień")]
    public DateTime? PermissionValidUntil { get; set; }

    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
