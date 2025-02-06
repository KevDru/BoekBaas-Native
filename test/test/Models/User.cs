using System.Collections.Generic;

namespace test.models
{

    public class User
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
           
            public string Role { get; set; }
            public ICollection<Book> BorrowedBooks { get; set; }
    }
}
