using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.models;

namespace test.Models
{

    internal class SeedController
    {
        private readonly AppDbContext _context = new AppDbContext();
        public void SeedDatabase()
        {
            SeedGenres(); 
            SeedUsers();  
            SeedBooks(); 
        }
        public SeedController(AppDbContext context)
        {
            _context = context;
        }

        private void SeedGenres()
        {
            if (!_context.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Fiction" },
                    new Genre { Name = "Non-Fiction" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Thriller" }
                };

                _context.Genres.AddRange(genres);
                _context.SaveChanges();
            }
        }

        private void SeedUsers()
        {
            if (!_context.Users.Any())
            {
                var users = new List<User>
                {
                    new User { Username = "test", Password = "test" },
                    new User { Username = "test2",  Password = "test" },
                    new User { Username = "admin",  Password = "admin" },
                };

                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
        }

        private void SeedBooks()
        {
            if (!_context.Books.Any())
            {
                var genres = _context.Genres.ToList(); // Get genres from the database (assuming they already exist)

                var books = new List<Book>
                {
                    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", publication_year = 1925, GenreId = genres.First(g => g.Name == "Fiction").Id, ISBN = "9780743273565", IsBorrowable = true },
                    new Book { Title = "1984", Author = "George Orwell", publication_year = 1949, GenreId = genres.First(g => g.Name == "Fiction").Id, ISBN = "9780451524935", IsBorrowable = true },
                    new Book { Title = "Dune", Author = "Frank Herbert", publication_year = 1965, GenreId = genres.First(g => g.Name == "Science Fiction").Id, ISBN = "9780441013593", IsBorrowable = true },
                    new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", publication_year = 1937, GenreId = genres.First(g => g.Name == "Fantasy").Id, ISBN = "9780345339683", IsBorrowable = true },
                    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", publication_year = 1813, GenreId = genres.First(g => g.Name == "Romance").Id, ISBN = "9780141439518", IsBorrowable = true }
                };

                _context.Books.AddRange(books);
                _context.SaveChanges();
            }
        }

    }
}
