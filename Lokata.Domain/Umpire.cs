using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Lokata.Domain.DataAnnotations;

namespace Lokata.Domain;

public class Umpire : EntityBase
{
    [Required(ErrorMessage = "Imię i nazwisko jest wymagane")]
    [Display(Name = "Imię i nazwisko")]
    [MaxLength(255)]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Dokument jest wymagany")]
    [Display(Name = "Dokument potwierdzający uprawnienia")]
    [MaxLength(255)]
    public string PermissionDocumentNumber { get; set; }


    [NotFutureDate]
    [Display(Name = "Data wydania uprawnień")]
    public DateTime? PermissionDocumentDate { get; set; }

    [NotPastDate]
    [Display(Name = "Data ważności uprawnień")]
    public DateTime? PermissionValidUntil { get; set; }

    [JsonIgnore]
    public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();
}
