using HamroKitab.Controllers;
using HamroKitab.Data.Base;
using HamroKitab.Model;
using Microsoft.EntityFrameworkCore;

namespace HamroKitab.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        public CategoryService(HamroDbContext context) : base(context) { }

    }
}