using HamroKitab.Data;
using Microsoft.AspNetCore.Mvc;
using HamroKitab.Data.Services;
using HamroKitab.Model;

namespace HamroKitab.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _service;
        public PublisherController(IPublisherService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var publishers = await _service.GetAllAsync();
            return View(publishers);
        }

        //Get: Publisher/Create
        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("Logo,Name,Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        //Get: Publisher/Details
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        //Get: Publisher/Edit 
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("Not Found");
            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _service.UpdateAsync(id, publisher);
            return RedirectToAction(nameof(Index));
        }

        //Get: Publisher/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("Not Found");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
