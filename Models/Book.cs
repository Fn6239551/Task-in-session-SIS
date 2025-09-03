using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*13. Books
Represents books available in libraries.
        Columns
BookId (PK, int, identity).
Title (nvarchar(200), required).
Author (nvarchar(200), required).
ISBN (nvarchar(20), required, unique).
LibraryId (FK → Libraries).
        Relationships
A Book belongs to one Library.
A Book can have many BookLoans.

  */
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public int LibraryId { get; set; }
        public Library Library { get; set; } = null!;
        public ICollection<BookLoan> BookLoans { get; set; } = new HashSet<BookLoan>();
    }
}
