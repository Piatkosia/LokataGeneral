using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Web.Models.AddressModels;
using Microsoft.AspNetCore.Mvc;

namespace Lokata.Web.Controllers
{
    public class AddressController : PopableController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IAddressService _addressService;

        public AddressController(ILogger<CategoryController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _List()
        {
            var addresses = await _addressService.GetAllAsync();
            var model = new AddressListViewModel
            {
                Addresses = addresses.ToList()
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
                var currentItem = await _addressService.GetById(id.Value);
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
        public async Task<IActionResult> Edit(Address address)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _addressService.Update(address);
                    SuccessPopup();
                    return RedirectToAction(nameof(Index));
                }
                return View(address);
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
                var currentItem = await _addressService.GetById(id.Value);
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
                var currentItem = await _addressService.GetById(id.Value);
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
                await _addressService.Delete(id);
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
        public async Task<IActionResult> Create(Address model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _addressService.Create(model);
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
