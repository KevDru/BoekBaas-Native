﻿using System;
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
        public Book Book { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; } 
        public DateTime? ReturnDate { get; set; } 
    }
}

