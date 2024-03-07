using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Address : EntityBase
{
    [Display(Name = "Nazwa")]
    [Required(ErrorMessage = "Nazwa jest wymagana")]
    [MaxLength(254)]
    public string FullName { get; set; }

    [Display(Name = "Ulica / Miejscowość")]
    [MaxLength(254)]
    public string Street { get; set; }

    [Display(Name = "Numer domu")]
    [MaxLength(50)]
    public string Number { get; set; }

    [Display(Name = "Kod pocztowy")]
    [MaxLength(50)]
    [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
    [RegularExpression(@"\d{2}-\d{3}", ErrorMessage = "Nieprawidłowy format kodu pocztowego. Przykład poprawnego: 11-111.")]
    public string PostalCode { get; set; }

    [MaxLength(254)]
    [Required(ErrorMessage = "Poczta jest wymagana")]
    [Display(Name = "Poczta")]
    public string PostalPlace { get; set; }

    [JsonIgnore]
    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
