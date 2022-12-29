using HamroKitab.Controllers;
using HamroKitab.Data.Base;
using HamroKitab.Data.ViewModels;
using HamroKitab.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;
using System.Threading.Tasks;

namespace HamroKitab.Data.Services
{
    public class BooksService : EntityBaseRepository<Books>, IBooksService
    {
        private readonly HamroDbContext _context;
        public BooksService(HamroDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Books()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                PublisherId = data.PublisherId,
                PublishDate = data.PublishDate
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
         
            //Add Book Categories  
            foreach (var categoryId in data.CategoryIds!)
            {
                var newCategoryBook = new Category_Books()
                {
                    BooksId = newBook.Id,
                    CategoryId = categoryId
                };
                await _context.Category_Books.AddAsync(newCategoryBook);
            }
            await _context.SaveChangesAsync();

            //Add Book Authors 
            foreach (var authorId in data.AuthorIds!)
            {
                var newAuthorBook = new Author_Books()
                {
                    BooksId = newBook.Id,
                    AuthorId = authorId
                };
                await _context.Author_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Books> GetBooksByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(p => p.Publisher!)
                .Include(ab => ab.Category_Books!).ThenInclude(a => a.Category)
                .Include(ab => ab.Author_Books!).ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails!;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Author = await _context.Author.OrderBy(n => n.FullName).ToListAsync(),
                Category = await _context.Category.OrderBy(n => n.Name).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync()

            };

            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbBook != null)
            {
                dbBook.Name = data.Name;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageUrl = data.ImageUrl;
                dbBook.PublisherId = data.PublisherId;
                dbBook.PublishDate = data.PublishDate;
                await _context.SaveChangesAsync();
            }

            //Remove existing authors
            var existingActorDb = _context.Author_Books.Where(n => n.BooksId == data.Id).ToList();
            _context.Author_Books.RemoveRange(existingActorDb);
            await _context.SaveChangesAsync();

            //Add Book Authors 
            foreach (var authorId in data.AuthorIds!)
            {
                var newAuthorBook = new Author_Books()
                {
                    BooksId = data.Id,
                    AuthorId = authorId
                };
                await _context.Author_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();

            //Remove existing Categories
            var existingCategoryDb = _context.Category_Books.Where(n => n.BooksId == data.Id).ToList();
            _context.Category_Books.RemoveRange(existingCategoryDb);
            await _context.SaveChangesAsync();

            //Add Book Categories
            foreach (var categoryId in data.CategoryIds!)
            {
                var newCategoryBook = new Category_Books()
                {
                    BooksId = data.Id,
                    CategoryId = categoryId
                };
                await _context.Category_Books.AddAsync(newCategoryBook);
            }
            await _context.SaveChangesAsync();
        }
    }
}