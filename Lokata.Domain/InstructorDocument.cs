using System.Text.Json.Serialization;

namespace Lokata.Domain
{
    public class InstructorDocument : EntityBase
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }

        [JsonIgnore]
        public Instructor Instructor { get; set; } = new Instructor();
        public int DocumentId { get; set; }

        [JsonIgnore]
        public Document Document { get; set; } = new Document();
    }
}
