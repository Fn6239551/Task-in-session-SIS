using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*14. BookLoans
Represents book borrowings by students.
        Columns
LoanId (PK, int, identity).
BookId (FK → Books).
StudentId (FK → Students).
LoanDate (datetime, required).
ReturnDate (datetime, optional).
        Relationships
A Student can borrow many Books.
A Book can be loaned multiple times.
  */
    public class BookLoan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
