using HamroKitab.Controllers;
using HamroKitab.Data.Base;
using HamroKitab.Model;
using Microsoft.EntityFrameworkCore;

namespace HamroKitab.Data.Services
{
    public class AuthorService : EntityBaseRepository<Author>, IAuthorService
    {
        public AuthorService(HamroDbContext context) : base(context) { } 

    }
}

