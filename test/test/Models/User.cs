using System.Collections.Generic;

namespace test.models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Collection to store borrowed books
        public ICollection<Book> BorrowedBooks { get; set; }
    }
}
