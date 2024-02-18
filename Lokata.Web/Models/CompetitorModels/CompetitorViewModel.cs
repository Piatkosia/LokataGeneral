using Lokata.Domain;
using System.ComponentModel.DataAnnotations;

namespace Lokata.Web.Models.CompetitorModels
{
    public class CompetitorViewModel
    {
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Wiek")]
        public int? Age { get; set; }

        [Display(Name = "Czy osoba jest niepełnosprawna?")]
        public bool IsDisabledPerson { get; set; }

        [Display(Name = "Czy osoba jest profesjonalistą?")]
        public bool Professional { get; set; }

        [Display(Name = "Płeć")]
        public int? SexId { get; set; }

        [Display(Name = "Imię (imiona) i nazwisko")]
        public string FullName { get; set; }

        public List<Sex> SexList { get; set; }
    }
}
