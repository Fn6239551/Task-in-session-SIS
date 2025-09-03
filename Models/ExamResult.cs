using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{/*11. ExamResults
Represents results of exams for students.
        Columns
ExamResultId (PK, int, identity).
ExamId (FK → Exams).
StudentId (FK → Students).
Score (decimal(5,2), required).
        Relationships
A Student gets one result per Exam.

  */
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public decimal Score { get; set; }
    }
}
