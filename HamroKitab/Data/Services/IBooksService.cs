using HamroKitab.Data.Base;
using HamroKitab.Data.ViewModels;
using HamroKitab.Model;
using System.Threading.Tasks;

namespace HamroKitab.Data.Services
{
    public interface IBooksService : IEntityBaseRepository<Books>
    {
        Task<Books> GetBooksByIdAsync(int id);

        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}
