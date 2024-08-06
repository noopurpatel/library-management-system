using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _991667498NoopurPatel
{
    public abstract class Book
    {
        private static int bookCounter = 0;

        public int BookId { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public BookType BookType { get; }

        public Book(string title, string author, int publicationYear, BookType bookType)
        {
            BookId = ++bookCounter;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            BookType = bookType;
        }

        public abstract decimal Price { get; set; }
    }

    public enum BookType
    {
        Fiction,
        NonFiction,
        Reference,
        Magazine
    }
}
