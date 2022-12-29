using HamroKitab.Data;
using Microsoft.AspNetCore.Mvc;
using HamroKitab.Data.Services;
using HamroKitab.Model;

namespace HamroKitab.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _service.GetAllAsync();
            return View(authors);
        }

        //Get: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            await _service.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }

        //Get: Author/Details
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not Found");
            return View(authorDetails);
        }

        //Get: Author/Edit 
        public async Task<IActionResult> Edit(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not Found");
            return View(authorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            await _service.UpdateAsync(id, author);
            return RedirectToAction(nameof(Index));
        }

        //Get: Author/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not Found");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
