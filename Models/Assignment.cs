using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*8. Assignments
Represents coursework assigned to students.
        Columns
AssignmentId (PK, int, identity).
CourseId (FK → Courses).
Title (nvarchar(200), required).
Description (nvarchar(max), optional).
DueDate (datetime, required).
        Relationships
Assignments belong to a Course.
Students submit work via Submissions.
  */
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        
        public Course Course { get; set; }
        public ICollection<Submission> Submissions { get; set; }=new HashSet<Submission>();
    }
}
