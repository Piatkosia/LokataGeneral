using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lokata.Domain;

public class Document : EntityBase
{
    [Display(Name = "Nazwa")]
    public string Name { get; set; }

    [Display(Name = "Nazwa pliku")]
    public string Filename { get; set; }
    [JsonIgnore]
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
    [JsonIgnore]
    public List<Instructor> Instructors { get; set; } = new();
}
