using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _991667498NoopurPatel
{
    public class Magazine : Book
    {
        public Magazine(string title, string author, int publicationYear)
            : base(title, author, publicationYear, BookType.Magazine) { }

        public override decimal Price { get; set; }
    }
}
