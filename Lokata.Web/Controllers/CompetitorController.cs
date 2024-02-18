using Lokata.Domain.Services;
using Lokata.Tools.PdfDomainObjects;
using Lokata.Web.Models.CompetitorModels;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.Web.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly ILogger<CompetitorController> _logger;
        private readonly ICompetitorService _competitorService;
        private readonly ISexService _sexService;

        public CompetitorController(ILogger<CompetitorController> logger, ICompetitorService competitorService, ISexService sexService)
        {
            _logger = logger;
            _competitorService = competitorService;
            _sexService = sexService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _List()
        {
            var competitors = await _competitorService.GetAllWithSex();
            var CompetitorListViewModel = new CompetitorListViewModel
            {
                Competitors = competitors.Select(x =>
                {
                    string sexName = x.SexId == null ? "" : x.Sex.Name;
                    return new CompetitorDetailsViewModel()
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        DateOfBirth = x.DateOfBirth,
                        Professional = x.Professional ?? false,
                        Age = x.Age,
                        IsDisabledPerson = x.IsDisabledPerson ?? false,
                        SexId = x.SexId,
                        SexName = sexName
                    };
                }).ToList()
            };
            return PartialView(CompetitorListViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var currentItem = await _competitorService.GetByIdWithSex(id.Value);

                if (currentItem == null)
                {
                    return NotFound();
                }
                var item = new CompetitorSexViewModel()
                {
                    Id = currentItem.Id,
                    FullName = currentItem.FullName,
                    DateOfBirth = currentItem.DateOfBirth,
                    Professional = currentItem.Professional ?? false,
                    Age = currentItem.Age,
                    IsDisabledPerson = currentItem.IsDisabledPerson ?? false,
                    //SexId = currentItem.SexId, żeby mi tych zer na razie nie ustawiał
                };
                return View(item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompetitorSexViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                await _competitorService.Update(model.ToCompetitor());
                TempData["Success"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var currentItem = await _competitorService.GetById(id.Value);
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
                var currentItem = await _competitorService.GetById(id.Value);
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
                await _competitorService.Delete(id);
                TempData["Success"] = true;
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
        public async Task<IActionResult> Create(CompetitorSexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _competitorService.Create(model.ToCompetitor());
                    TempData["Success"] = true;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return View(model);
        }

        public async Task<ActionResult> GeneratePdf()
        {
            var competitions = await _competitorService.GetAllWithSex();
            var pdf = new CompetitorsListPdf();
            var stream = pdf.GetPdf(competitions);

            return File(stream, "application/pdf", "Zawodnicy.pdf");
        }
    }
}
