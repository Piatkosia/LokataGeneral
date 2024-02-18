using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain
{
    public class InstructorDocument : EntityBase
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Instruktor")]
        public int InstructorId { get; set; }

        [JsonIgnore]
        public Instructor Instructor { get; set; } = new Instructor();

        [Display(Name = "Dokument")]
        public int DocumentId { get; set; }

        [JsonIgnore]
        public Document Document { get; set; } = new Document();
    }
}
