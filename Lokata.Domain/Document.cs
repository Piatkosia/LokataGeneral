using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Document : EntityBase
{
    public string Name { get; set; }

    public string Filename { get; set; }
    [JsonIgnore]
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
    [JsonIgnore]
    public List<Instructor> Instructors { get; set; } = new();
}
