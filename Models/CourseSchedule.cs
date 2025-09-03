using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    /*7. CourseSchedules
Represents the scheduling of a course with an instructor and a classroom.
        Columns
ScheduleId (PK, int, identity).
CourseId (FK → Courses).
InstructorId (FK → Instructors).
ClassroomId (FK → Classrooms).
DayOfWeek (nvarchar(20), required).
StartTime (time, required).
EndTime (time, required).
       Relationships
Each schedule links a Course, Instructor, and Classroom.

     */
    public class CourseSchedule
    {
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int ClassroomId { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Course Course { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;
        public Classroom Classroom { get; set; } = null!;

    }
}
