using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Tools.PdfDomainObjects;
using Lokata.Web.Models.CompetitorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lokata.Web.Controllers
{
    public class CompetitorController : PopableController
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
            var competitorListViewModel = new CompetitorListViewModel
            {
                Competitors = competitors.Select(GetCompetitorDetailsViewModel).ToList()
            };
            return PartialView(competitorListViewModel);
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
                    SexId = currentItem.SexId,
                };
                item.Sexes = await GetSexList();
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
                SuccessPopup();
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
                var currentItem = await _competitorService.GetByIdWithSex(id.Value);
                if (currentItem == null)
                {
                    return NotFound();
                }
                return View(GetCompetitorDetailsViewModel(currentItem));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        private static CompetitorDetailsViewModel GetCompetitorDetailsViewModel(Competitor currentItem)
        {
            var item = new CompetitorDetailsViewModel()
            {
                Id = currentItem.Id,
                FullName = currentItem.FullName,
                DateOfBirth = currentItem.DateOfBirth,
                Professional = currentItem.Professional ?? false,
                Age = currentItem.Age,
                IsDisabledPerson = currentItem.IsDisabledPerson ?? false,
                SexId = currentItem.SexId,
                SexName = currentItem.SexId == null ? "" : currentItem.Sex.Name
            };
            return item;
        }

        public async Task<IActionResult> Delete(int? id)
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
                return View(GetCompetitorDetailsViewModel(currentItem));
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

        public async Task<IActionResult> Create()
        {
            var model = new CompetitorSexViewModel();
            model.Sexes = await GetSexList();
            return View(model);
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

        public async Task<ActionResult> GeneratePdf()
        {
            var competitions = await _competitorService.GetAllWithSex();
            var pdf = new CompetitorsListPdf();
            var stream = pdf.GetPdf(competitions);

            return File(stream, "application/pdf", "Zawodnicy.pdf");
        }

        public async Task<List<Sex>> GetSexList()
        {
            CacheSexes ??= await _sexService.GetAll().ToListAsync();
            return CacheSexes;
        }

        public List<Sex> CacheSexes { get; set; }
    }
}
