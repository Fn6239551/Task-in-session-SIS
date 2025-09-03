using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*9. Submissions
Represents student submissions for assignments.
        Columns
SubmissionId (PK, int, identity).
AssignmentId (FK → Assignments).
StudentId (FK → Students).
SubmissionDate (datetime, required).
Grade (decimal(5,2), optional).
        Relationships
A Student submits work for an Assignment.
One Assignment has many Submissions.
  */
    public class Submission
    {
        public int SubmissionId { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal? Grade { get; set; }
        public Assignment Assignment { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}
