using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    /*4. Courses
Represents academic courses offered by departments.
       Columns
CourseId (PK, int, identity).
Title (nvarchar(200), required).
Credits (int, required, >0).
DepartmentId (FK → Departments).
        Relationships
One Course belongs to one Department.
Courses have many Enrollments (Students).
Courses have many Assignments and Exams.
Courses are scheduled with Instructors and Classrooms.

     */
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<Assignment> Assignments { get; set; } = new HashSet<Assignment>();
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<CourseSchedule> CourseSchedules { get; set; } = new HashSet<CourseSchedule>();

    }
}
