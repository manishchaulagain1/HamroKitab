using HamroKitab.Data;
using Microsoft.AspNetCore.Mvc;
using HamroKitab.Data.Services;
using HamroKitab.Model;

namespace HamroKitab.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCategories = await _service.GetAllAsync();
            return View(allCategories);
        }

        //GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        //GET: Categeory/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
                return View("NotFound");
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _service.UpdateAsync(id, category);
            return RedirectToAction(nameof(Index));
        }

        //GET: Category/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null)
                return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}