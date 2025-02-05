using System.ComponentModel.DataAnnotations;

namespace test.models
{
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public int publication_year { get; set; }
        public bool IsBorrowable { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public string ISBN { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        
    }
}
