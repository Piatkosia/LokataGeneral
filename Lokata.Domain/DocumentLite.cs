using System.ComponentModel.DataAnnotations;

namespace Lokata.Domain
{
    /// <summary>
    /// Dokument, ale bez zawartości pliku
    /// </summary>
    public class DocumentLite
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Nazwa pliku")]
        public string Filename { get; set; }
    }
}
