using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    /*6. Classrooms
Represents physical classrooms.
    Columns
ClassroomId (PK, int, identity).
Building (nvarchar(100), required).
RoomNumber (nvarchar(50), required).
Capacity (int, required, >0).
    Relationships
Classrooms are linked to Courses via CourseSchedules.

     */
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string Building { get; set; } = null!;
        public string RoomNumber { get; set; } = null!;
        public int Capacity { get; set; }
        public ICollection<CourseSchedule> CourseSchedules { get; set; } = new HashSet<CourseSchedule>();
    }
}
