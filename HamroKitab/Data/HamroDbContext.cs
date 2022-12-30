using HamroKitab.Model;
using HamroKitab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HamroKitab.Data
{
    public class HamroDbContext : IdentityDbContext<ApplicationUser>
    {
        public HamroDbContext (DbContextOptions<HamroDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Author_Books>().HasKey(am => new
            {
                am.AuthorId,
                am.BooksId
            });*/

            modelBuilder.Entity<Author_Books>().HasOne(m => m.Books).WithMany(am => am.Author_Books).HasForeignKey(m => m.BooksId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Author_Books>().HasOne(m => m.Author).WithMany(am => am.Author_Books).HasForeignKey(m => m.AuthorId).OnDelete(DeleteBehavior.Cascade);
            

           /* modelBuilder.Entity<Category_Books>().HasKey(am => new
            {
                am.CategoryId,
                am.BooksId
            });*/

            modelBuilder.Entity<Category_Books>().HasOne(m => m.Books).WithMany(am => am.Category_Books).HasForeignKey(m => m.BooksId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category_Books>().HasOne(m => m.Category).WithMany(am => am.Category_Books).HasForeignKey(m => m.CategoryId).OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Author> Author { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Books> Books { get; set; } = null!;
        public DbSet<Author_Books> Author_Books { get; set; } = null!;
        public DbSet<Category_Books> Category_Books { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}