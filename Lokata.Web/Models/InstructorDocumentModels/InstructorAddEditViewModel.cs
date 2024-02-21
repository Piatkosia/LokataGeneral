using Lokata.Domain;
using System.ComponentModel.DataAnnotations;

namespace Lokata.Web.Models.InstructorDocumentModels
{
    public class InstructorAddEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Instruktor")]
        public int InstructorId { get; set; }

        [Display(Name = "Dokument")]
        public int DocumentId { get; set; }

        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Document> Documents { get; set; } = new List<Document>();

        public InstructorDocument ToInstructorDocument()
        {
            return new InstructorDocument
            {
                Id = Id,
                Name = Name,
                InstructorId = InstructorId,
                DocumentId = DocumentId
            };
        }
    }
}
