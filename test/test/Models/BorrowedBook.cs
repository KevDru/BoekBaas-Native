using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.models
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } // Navigation property to Book
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property to User
        public DateTime? ReturnDate { get; set; } // Nullable return date (for borrowed books)
    }
}

