using System.ComponentModel.DataAnnotations;

namespace Lokata.Domain;

public class Category : EntityBase
{
    [Display(Name = "Nazwa kategorii")]
    [Required(ErrorMessage = "Nazwa jest wymagana")]
    public string CategoryName { get; set; }

    [Display(Name = "Minimalny wiek")]
    [Range(4, 120, ErrorMessage = "Minimalny wiek musi być z przedziału 4-120")]
    public int MinAgeInYears { get; set; } = 6;

    [Display(Name = "Maksymalny wiek")]
    [Range(4, 120, ErrorMessage = "Maksymalny wiek musi być z przedziału 4-120")]
    public int? MaxAgeInYears { get; set; } = 120;

    [Display(Name = "Dla niepełnosprawnych")]
    public bool ForDisabled { get; set; }

    [Display(Name = "Dla profesjonalistów")]
    public bool ForProfessional { get; set; }

    [Display(Name = "Dla kobiet")]
    public bool ForFemale { get; set; }

    [Display(Name = "Dla mężczyzn")]
    public bool ForMale { get; set; }
}
