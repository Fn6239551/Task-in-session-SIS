using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*10. Exams
Represents exams for courses.
        Columns
ExamId (PK, int, identity).
CourseId (FK → Courses).
ExamDate (datetime, required).
Type (nvarchar(50), required: Midterm/Final).
        Relationships
Exams belong to a Course.
Exams have many ExamResults.

  */
    public class Exam
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public DateTime ExamDate { get; set; }
        public string Type { get; set; } = null!;
        public ICollection<ExamResult> ExamResults { get; set; } = new HashSet<ExamResult>();
    }
}
