using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    /*12. Libraries
Represents university libraries.
        Columns
LibraryId (PK, int, identity).
Name (nvarchar(200), required).
Location (nvarchar(200), required).
        Relationships
A Library contains many Books.

     */
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
