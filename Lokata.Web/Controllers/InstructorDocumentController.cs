using Lokata.Domain.Services;
using Lokata.Web.Models.InstructorDocumentModels;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.Web.Controllers
{
    public class InstructorDocumentController : PopableController
    {
        private readonly ILogger<InstructorDocumentController> _logger;
        private readonly IInstructorDocumentService _instructorDocumentService;
        private readonly IInstructorService _instructorService;
        private readonly IDocumentService _documentService;

        public InstructorDocumentController(IInstructorDocumentService instructorDocumentService,
            IInstructorService instructorService,
            IDocumentService documentService,
            ILogger<InstructorDocumentController> logger)
        {
            _instructorDocumentService = instructorDocumentService;
            _instructorService = instructorService;
            _documentService = documentService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _List()
        {
            var items = await _instructorDocumentService.GetAllWithDependencies();
            var model = new InstructorDocumentListViewModel
            {
                InstructorDocuments = items.Select(x => new InstructorListViewModelItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    InstructorName = x.Instructor.FullName,
                    DocumentName = x.Document.Name,
                    InstructorId = x.InstructorId,
                    DocumentId = x.DocumentId
                }).ToList()
            };

            return PartialView(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var currentItem = await _instructorDocumentService.GetByIdWithDependencies(id.Value);
                if (currentItem == null)
                {
                    return NotFound();
                }
                var viewItem = new InstructorListViewModelItem
                {
                    Id = currentItem.Id,
                    Name = currentItem.Name,
                    InstructorName = currentItem.Instructor.FullName,
                    DocumentName = currentItem.Document.Name,
                    InstructorId = currentItem.InstructorId,
                    DocumentId = currentItem.DocumentId
                };
                return View(viewItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        public async Task<IActionResult> Create()
        {
            InstructorAddEditViewModel model = await GetEmptyModel();
            return View(model);
        }

        private async Task<InstructorAddEditViewModel> GetEmptyModel()
        {
            InstructorAddEditViewModel model = new InstructorAddEditViewModel();
            model.Instructors = (await _instructorService.GetAllAsync()).ToList();
            model.Documents = (await _documentService.GetAllAsync()).ToList();
            return model;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorAddEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = model.ToInstructorDocument();
                    item.Instructor = null;
                    item.Document = null;
                    await _instructorDocumentService.Create(item);
                    SuccessPopup();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var currentItem = await _instructorDocumentService.GetById(id.Value);
                if (currentItem == null)
                {
                    return NotFound();
                }
                var currentModel = await GetEmptyModel();
                currentModel.Id = currentItem.Id;
                currentModel.Name = currentItem.Name;
                currentModel.InstructorId = currentItem.InstructorId;
                currentModel.DocumentId = currentItem.DocumentId;

                return View(currentModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InstructorAddEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                var item = model.ToInstructorDocument();
                item.Instructor = null;
                item.Document = null;
                await _instructorDocumentService.Update(item);
                SuccessPopup();
                return RedirectToAction(nameof(Index));
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
                var currentItem = await _instructorDocumentService.GetByIdWithDependencies(id.Value);
                if (currentItem == null)
                {
                    return NotFound();
                }
                var viewItem = new InstructorListViewModelItem
                {
                    Name = currentItem.Name,
                    InstructorName = currentItem.Instructor.FullName,
                    DocumentName = currentItem.Document.Name,
                    InstructorId = currentItem.InstructorId,
                    DocumentId = currentItem.DocumentId
                };
                return View(viewItem);
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
                await _instructorDocumentService.Delete(id);
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
    }
}
