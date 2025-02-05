﻿using System.Collections.Generic;

namespace test.models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }  // Each genre can have multiple books
    }
}
