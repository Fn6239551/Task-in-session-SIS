using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    /*3. Instructors
Represents teaching staff.
    Columns
InstructorId (PK, int, identity).
FullName (nvarchar(200), required).
Email (nvarchar(150), required, unique).
Phone (nvarchar(20), optional).
HireDate (date, required).
DepartmentId (FK → Departments).
    Relationships
One Instructor belongs to one Department.
One Instructor can teach many Courses via CourseSchedules.
One Instructor can be Head of a Department.

     */
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<CourseSchedule> CourseSchedules { get; set; } = new HashSet<CourseSchedule>();
        //public ICollection<Department> HeadedDepartments { get; set; } = new HashSet<Department>();

    }
}
