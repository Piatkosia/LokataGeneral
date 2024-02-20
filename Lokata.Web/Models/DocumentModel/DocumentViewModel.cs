using System.ComponentModel.DataAnnotations;

namespace Lokata.Web.Models.DocumentModel
{
    public class DocumentViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Plik")]
        public IFormFile File { get; set; }

        [Display(Name = "Nazwa pliku")]
        public string Filename { get; set; }
    }
}
