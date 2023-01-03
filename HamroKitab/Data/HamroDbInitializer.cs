using HamroKitab.Data.Static;
using HamroKitab.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamroKitab.Data
{
    public class HamroDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HamroDbContext>();

                context!.Database.EnsureCreated();

                //Author
                if (!context.Author.Any())
                {
                    context.Author.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "Bhanubhakta",
                            Bio = "This is the Bio of the author",
                            ProfilePictureUrl = "https://www.imnepal.com/wp-content/uploads/2017/04/bhanubhakta.jpg"
                        },
                        new Author()
                        {
                            FullName = "Bishhweshwar Prasad Koirals",
                            Bio = "This is the Bio of the author",
                            ProfilePictureUrl = "https://www.imnepal.com/wp-content/uploads/2017/04/bishhweshwar-prasad-koirals.jpg"
                        },
                        new Author()
                        {
                            FullName = "Lekhnth Poudyal",
                            Bio = "This is the Bio of the author",
                            ProfilePictureUrl = "https://www.imnepal.com/wp-content/uploads/2017/04/lekhnth-poudyal.jpg"
                        },
                        new Author()
                        {
                            FullName = "Author 4",
                            Bio = "This is the Bio of the author",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Author()
                        {
                            FullName = "Author 5",
                            Bio = "This is the Bio of the author",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //Publisher
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            Name = "Publisher 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the Publisher"
                        },
                        new Publisher()
                        {
                            Name = "Publisher 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the Publisher"
                        },
                        new Publisher()
                        {
                            Name = "Publisher 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the Publisher"
                        },
                        new Publisher()
                        {
                            Name = "Publisher 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the Publisher"
                        },
                        new Publisher()
                        {
                            Name = "Publisher 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the Publisher"
                        },
                    });
                    context.SaveChanges();
                }

                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Books>()
                    {
                        new Books()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            PublishDate = DateTime.Now ,
                            PublisherId = 3,
                        },
                        new Books()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            PublishDate = DateTime.Now,
                            PublisherId = 1,
                        },
                        new Books()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            PublishDate = DateTime.Now,
                            PublisherId= 4,
                        },
                        new Books()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            PublishDate = DateTime.Now,
                            PublisherId = 2,
                        },
                        new Books()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            PublishDate = DateTime.Now,
                            PublisherId = 3,
                        },
                        new Books()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            PublishDate = DateTime.Now,
                            PublisherId = 5,
                        }
                    });
                    context.SaveChanges();
                }

                //Category
                if (!context.Category.Any())
                {
                    context.Category.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "A",
                        },
                        new Category()
                        {
                            Name = "B",
                        },
                        new Category()
                        {
                            Name = "C",
                        },
                        new Category()
                        {
                            Name = "D",
                        },
                        new Category()
                        {
                            Name = "E"
                        },
                        new Category()
                        {
                            Name = "F"
                        }
                    });
                    context.SaveChanges();
                }

                //Author & Books
                if (!context.Author_Books.Any())
                {
                    context.Author_Books.AddRange(new List<Author_Books>()
                    {
                        new Author_Books()
                        {
                            AuthorId = 1,
                            BooksId = 1
                        },
                        new Author_Books()
                        {
                            AuthorId = 3,
                            BooksId = 1
                        },
                         new Author_Books()
                        {
                            AuthorId = 1,
                            BooksId = 2
                        },
                         new Author_Books()
                        {
                            AuthorId = 4,
                            BooksId = 2
                        },
                        new Author_Books()
                        {
                            AuthorId = 1,
                            BooksId = 3
                        },
                        new Author_Books()
                        {
                            AuthorId = 2,
                            BooksId = 3
                        },
                        new Author_Books()
                        {
                            AuthorId = 5,
                            BooksId = 3
                        },
                        new Author_Books()
                        {
                            AuthorId = 2,
                            BooksId = 4
                        },
                        new Author_Books()
                        {
                            AuthorId = 3,
                            BooksId = 4
                        },
                        new Author_Books()
                        {
                            AuthorId = 4,
                            BooksId = 4
                        },
                        new Author_Books()
                        {
                            AuthorId = 2,
                            BooksId = 5
                        },
                        new Author_Books()
                        {
                            AuthorId = 3,
                            BooksId = 5
                        },
                        new Author_Books()
                        {
                            AuthorId = 4,
                            BooksId = 5
                        },
                        new Author_Books()
                        {
                            AuthorId = 5,
                            BooksId = 5
                        },
                        new Author_Books()
                        {
                            AuthorId = 3,
                            BooksId = 6
                        },
                        new Author_Books()
                        {
                            AuthorId = 4,
                            BooksId = 6
                        },
                        new Author_Books()
                        {
                            AuthorId = 5,
                            BooksId = 6
                        },
                    });
                    context.SaveChanges();
                }

                //Category & Books
                if (!context.Category_Books.Any())
                {
                    context.Category_Books.AddRange(new List<Category_Books>()
                    {
                        new Category_Books()
                        {
                            CategoryId = 1,
                            BooksId = 1
                        },
                        new Category_Books()
                        {
                            CategoryId = 3,
                            BooksId = 1
                        },
                         new Category_Books()
                        {
                            CategoryId = 1,
                            BooksId = 2
                        },
                         new Category_Books()
                        {
                            CategoryId = 4,
                            BooksId = 2
                        },
                        new Category_Books()
                        {
                            CategoryId = 1,
                            BooksId = 3
                        },
                        new Category_Books()
                        {
                            CategoryId = 2,
                            BooksId = 3
                        },
                        new Category_Books()
                        {
                            CategoryId = 5,
                            BooksId = 3
                        },
                        new Category_Books()
                        {
                            CategoryId = 2,
                            BooksId = 4
                        },
                        new Category_Books()
                        {
                            CategoryId = 3,
                            BooksId = 4
                        },
                        new Category_Books()
                        {
                            CategoryId = 4,
                            BooksId = 4
                        },
                        new Category_Books()
                        {
                            CategoryId = 2,
                            BooksId = 5
                        },
                        new Category_Books()
                        {
                            CategoryId = 3,
                            BooksId = 5
                        },
                        new Category_Books()
                        {
                            CategoryId = 4,
                            BooksId = 5
                        },
                        new Category_Books()
                        {
                            CategoryId = 5,
                            BooksId = 5
                        },
                        new Category_Books()
                        {
                            CategoryId = 3,
                            BooksId = 6
                        },
                        new Category_Books()
                        {
                            CategoryId = 4,
                            BooksId = 6
                        },
                        new Category_Books()
                        {
                            CategoryId = 5,
                            BooksId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@hamrobook.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Hamro#@333");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@hamrobook.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Hamro#@333");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

