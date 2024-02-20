using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Web.Models.InstructorModels;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.Web.Controllers
{
    public class InstructorController : PopableController
    {
        private readonly ILogger<InstructorController> _logger;
        private readonly IInstructorService _instructorService;

        public InstructorController(ILogger<InstructorController> logger, IInstructorService instructorService)
        {
            _logger = logger;
            _instructorService = instructorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _List()
        {
            var instructores = await _instructorService.GetAllAsync();
            var model = new InstructorListViewModel
            {
                Instructors = instructores.ToList()
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
                var currentItem = await _instructorService.GetById(id.Value);
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
        public async Task<IActionResult> Edit(Instructor instructor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _instructorService.Update(instructor);
                    SuccessPopup();
                    return RedirectToAction(nameof(Index));
                }
                return View(instructor);
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
                var currentItem = await _instructorService.GetById(id.Value);
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
                var currentItem = await _instructorService.GetById(id.Value);
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
                await _instructorService.Delete(id);
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
        public async Task<IActionResult> Create(Instructor model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _instructorService.Create(model);
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
