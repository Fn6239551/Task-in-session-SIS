using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*5. Enrollments
Represents the many-to-many relationship between Students and Courses.
         Columns
EnrollmentId (PK, int, identity).
StudentId (FK → Students).
CourseId (FK → Courses).
Grade (decimal(5,2), optional).
        Relationships
A Student can enroll in multiple Courses.
A Course can have multiple Students.
Unique constraint on (StudentId, CourseId).

  */
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal? Grade { get; set; }
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
