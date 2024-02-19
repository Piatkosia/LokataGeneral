using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Web.Models.SexModels;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.Web.Controllers
{
    public class SexController : PopableController
    {
        private readonly ILogger<SexController> _logger;
        private readonly ISexService _sexService;

        public SexController(ILogger<SexController> logger, ISexService sexService)
        {
            _logger = logger;
            _sexService = sexService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _List()
        {
            var sexes = await _sexService.GetAllAsync();
            var model = new SexListViewModel
            {
                Sexes = sexes.ToList()
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
                var currentItem = await _sexService.GetById(id.Value);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Sex sex)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _sexService.Update(sex);
                    SuccessPopup();
                    return RedirectToAction(nameof(Index));
                }
                return View(sex);
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
                var currentItem = await _sexService.GetById(id.Value);
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
                var currentItem = await _sexService.GetById(id.Value);
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
                await _sexService.Delete(id);
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
        public async Task<IActionResult> Create(Sex model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _sexService.Create(model);
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
    }
}
