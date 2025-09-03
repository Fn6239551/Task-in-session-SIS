using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*
  * 2. Departments
Represents academic departments in the university.
    Columns
DepartmentId (PK, int, identity).
Name (nvarchar(200), required, unique).
OfficeLocation (nvarchar(100), optional).
HeadOfDepartmentId (FK → Instructors, nullable).
   Relationships
One Department has many Students, Instructors, and Courses.
HeadOfDepartment is an Instructor (nullable).
*/
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }=null!;
        public string? OfficeLocation { get; set; }
        public int? HeadOfDepartmentId { get; set; }
        public Instructor? HeadOfDepartment { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
