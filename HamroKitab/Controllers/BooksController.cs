using HamroKitab.Data;
using HamroKitab.Data.Services;
using HamroKitab.Model;
using HamroKitab.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HamroKitab.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _service;
        public BooksController(IBooksService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks= await _service.GetAllAsync(n => n.Publisher!);   
            return View(allBooks);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Publisher!);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allBooks.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }

        //GET : Books/Details
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBooksByIdAsync(id);
            return View(bookDetail);
        }

        //GET : Books/Create 
        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers,"Id","Name");
            ViewBag.Author = new SelectList(bookDropdownsData.Author, "Id", "FullName");
            ViewBag.Category = new SelectList(bookDropdownsData.Category, "Id", "Name");

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM Book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();

                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Author = new SelectList(bookDropdownsData.Author, "Id", "FullName");
                ViewBag.Category = new SelectList(bookDropdownsData.Category, "Id", "Name");

                return View(Book);
            }
            await _service.AddNewBookAsync(Book);
            return RedirectToAction(nameof(Index));
        }
        //GET : Books/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBooksByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Name = bookDetails.Name,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                ImageUrl = bookDetails.ImageUrl,
                PublisherId = bookDetails.PublisherId,
                AuthorIds = bookDetails.Author_Books!.Select(n => n.AuthorId).ToList(),
                CategoryIds = bookDetails.Category_Books!.Select(n => n.CategoryId).ToList()
            };

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Author = new SelectList(bookDropdownsData.Author, "Id", "FullName");
            ViewBag.Category = new SelectList(bookDropdownsData.Category, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM Book)
        {
            if (id != Book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();

                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Author = new SelectList(bookDropdownsData.Author, "Id", "FullName");
                ViewBag.Category = new SelectList(bookDropdownsData.Category, "Id", "Name");

                return View(Book);
            }
            await _service.UpdateBookAsync(Book);
            return RedirectToAction(nameof(Index));
        }
    }
}
