using System.ComponentModel.DataAnnotations;

namespace Lokata.Web.Models.InstructorDocumentModels
{
    public class InstructorListViewModelItem
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nazwa ")]
        public string Name { get; set; }

        [Display(Name = "Imię i nazwisko insturktora")]
        public string InstructorName { get; set; }

        [Display(Name = "Nazwa dokumentu")]
        public string DocumentName { get; set; }

        public int InstructorId { get; set; }
        public int DocumentId { get; set; }
    }
}
