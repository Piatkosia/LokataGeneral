namespace Lokata.Domain
{
    public class InstructorDocument : EntityBase
    {
        int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = new Instructor();
        public int DocumentId { get; set; }
        public Document Document { get; set; } = new Document();
    }
}
