using System.ComponentModel.DataAnnotations;

namespace Lokata.Web.Models.CompetitorModels
{
    public class CompetitorDetailsViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Imię (imiona) i nazwisko")]
        public string FullName { get; set; }

        [Display(Name = "Data urodzenia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Wiek")]
        public int? Age { get; set; }

        [Display(Name = "Czy osoba jest niepełnosprawna?")]
        public bool IsDisabledPerson { get; set; }

        [Display(Name = "Czy osoba jest profesjonalistą?")]
        public bool Professional { get; set; }

        [Display(Name = "Płeć")]
        public string SexName { get; set; }

        [Display(Name = "Id płci")]
        public int? SexId { get; set; }
    }
}
