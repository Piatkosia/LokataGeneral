using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Web.Models.DocumentModel;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.Web.Controllers
{
    public class DocumentController : PopableController
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentService _documentService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _List()
        {
            var documents = await _documentService.GetAllLite();
            var model = new DocumentListViewModel
            {
                Documents = documents.ToList()
            };

            return PartialView(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var document = await _documentService.GetById(id.Value);
                if (document == null)
                {
                    return NotFound();
                }
                var model = new DocumentViewModel
                {
                    Id = document.Id,
                    Name = document.Name,
                    Filename = document.Filename
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var documentToUpdate = await _documentService.GetById(model.Id);

                    if (documentToUpdate == null)
                    {
                        return NotFound();
                    }

                    documentToUpdate.Name = model.Name;

                    if (model.File is { Length: > 0 })
                    {
                        await using var memoryStream = new MemoryStream();
                        await model.File.CopyToAsync(memoryStream);
                        documentToUpdate.FileContent = memoryStream.ToArray();
                        documentToUpdate.Filename = model.File.FileName;
                    }

                    await _documentService.Update(documentToUpdate);
                    SuccessPopup();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var currentItem = await _documentService.GetById(id.Value);
                if (currentItem == null)
                {
                    return NotFound();
                }
                return View(currentItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var currentItem = await _documentService.GetById(id.Value);
                if (currentItem == null)
                {
                    return NotFound();
                }
                return View(currentItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _documentService.Delete(id);
                SuccessPopup();
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Document document;
                    if (model.File is { Length: > 0 })
                    {
                        document = new Document
                        {
                            Name = model.Name,
                            Filename = model.File.FileName,
                            FileContent = await GetFileBytes(model.File),
                        };
                    }
                    else
                    {
                        document = new Document
                        {
                            Name = model.Name,
                        };
                    }
                    document = new Document
                    {
                        Name = model.Name,
                        Filename = model.File.FileName,
                        FileContent = await GetFileBytes(model.File),
                    };
                    await _documentService.Create(document);
                    SuccessPopup();
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        private async Task<byte[]> GetFileBytes(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Array.Empty<byte>();
            }

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            return stream.ToArray();
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var document = await _documentService.GetById(id);
            if (document == null)
            {
                return NotFound();
            }

            return File(document.FileContent, "application/octet-stream", document.Filename);
        }
    }

}
