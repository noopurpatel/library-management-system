﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _991667498NoopurPatel
{
    public class NonFictionBook : Book
    {
        public NonFictionBook(string title, string author, int publicationYear)
            : base(title, author, publicationYear, BookType.NonFiction) { }

        public override decimal Price { get; set; }
    }
}
