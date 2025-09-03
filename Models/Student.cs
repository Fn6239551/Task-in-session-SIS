using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    /*
     * 1. Students
Stores information about students enrolled in the university.
     Columns
StudentId (PK, int, identity) - Unique identifier.
FullName (nvarchar(200), required).
Email (nvarchar(150), required, unique).
Phone (nvarchar(20), optional).
BirthDate (date, required).
Address (nvarchar(300), optional).
DepartmentId (FK → Departments).
    Relationships
Each student belongs to one Department.
Students can enroll in many Courses via Enrollments.
Students can submit Assignments and take Exams.
Students can borrow Books via BookLoans.

     */
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();

        public ICollection<Submission> AssignmentSubmissions { get; set; } = new HashSet<Submission>();
        public ICollection<ExamResult> ExamResults { get; set; } = new HashSet<ExamResult>();
        public ICollection<BookLoan> BookLoans { get; set; } = new HashSet<BookLoan>();

    }
}
