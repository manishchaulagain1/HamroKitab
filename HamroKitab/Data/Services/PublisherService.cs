using HamroKitab.Data.Base;
using HamroKitab.Model;
using Microsoft.EntityFrameworkCore;

namespace HamroKitab.Data.Services
{
    public class PublisherService : EntityBaseRepository<Publisher>, IPublisherService
    {
        public PublisherService(HamroDbContext context) : base(context) { }

    }
}
