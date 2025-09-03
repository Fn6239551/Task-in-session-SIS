using Microsoft.EntityFrameworkCore;
using Student_Information_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Data
{
    public class SISContext : DbContext
    {
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Classroom> Classrooms => Set<Classroom>();
        public DbSet<CourseSchedule> CourseSchedules => Set<CourseSchedule>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<Submission> Submissions => Set<Submission>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<ExamResult> ExamResults => Set<ExamResult>();
        public DbSet<Library> Libraries => Set<Library>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookLoan> BookLoans => Set<BookLoan>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-SMBVS1T;Database=SISDB;Trusted_Connection=True;TrustServerCertificate=True;AttachDbFilename=D:\Databases\SISDB.mdf");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Department
            modelBuilder.Entity<Department>(e =>
            {
                e.HasKey(d => d.DepartmentId);
                e.HasIndex(d => d.Name).IsUnique();
                e.Property(d => d.Name).IsRequired().HasMaxLength(200);
                e.Property(d => d.OfficeLocation).HasMaxLength(100);
                e.HasOne(d => d.HeadOfDepartment)
                 .WithMany()
                 .HasForeignKey(d => d.HeadOfDepartmentId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            //Student
            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(s => s.StudentId);
                e.HasIndex(s => s.Email).IsUnique();
                e.Property(s => s.FullName).IsRequired().HasMaxLength(200);
                e.Property(s => s.Email).IsRequired().HasMaxLength(150);
                e.Property(s => s.Phone).HasMaxLength(20);
                e.Property(s => s.BirthDate).IsRequired();
                e.Property(s => s.Address).HasMaxLength(300);
                e.HasOne(s => s.Department)
                 .WithMany(d => d.Students)
                 .HasForeignKey(s => s.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            //Instructor
            modelBuilder.Entity<Instructor>(e =>
            {
                e.HasKey(i => i.InstructorId);
                e.HasIndex(i => i.Email).IsUnique();
                e.Property(i => i.FullName).IsRequired().HasMaxLength(200);
                e.Property(i => i.Email).IsRequired().HasMaxLength(150);
                e.Property(i => i.Phone).HasMaxLength(20);
                e.Property(i => i.HireDate).IsRequired();
                e.HasOne(i => i.Department)
                 .WithMany(d => d.Instructors)
                 .HasForeignKey(i => i.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            //Course
            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(c => c.CourseId);
                e.Property(c => c.Title).IsRequired().HasMaxLength(200);
                e.Property(c => c.Credits).IsRequired();
                e.HasCheckConstraint("CK_Course_Credits", "[Credits] > 0");
                e.HasOne(c => c.Department)
                 .WithMany(d => d.Courses)
                 .HasForeignKey(c => c.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            //Classroom
            modelBuilder.Entity<Classroom>(e =>
            {
                e.HasKey(c => c.ClassroomId);
                e.Property(c => c.Building).IsRequired().HasMaxLength(100);
                e.Property(c => c.RoomNumber).IsRequired().HasMaxLength(50);
                e.Property(c => c.Capacity).IsRequired();
                e.HasCheckConstraint("CK_Classroom_Capacity", "[Capacity] > 0");
            });

            //CourseSchedule
            modelBuilder.Entity<CourseSchedule>(e =>
            {
                e.HasKey(cs => cs.ScheduleId);
                e.Property(cs => cs.DayOfWeek).IsRequired().HasMaxLength(20);
                e.Property(cs => cs.StartTime).IsRequired();
                e.Property(cs => cs.EndTime).IsRequired();
                e.HasCheckConstraint("CK_CourseSchedule_Time", "[EndTime] > [StartTime]");
                e.HasOne(cs => cs.Course)
                 .WithMany(c => c.CourseSchedules)
                 .HasForeignKey(cs => cs.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(cs => cs.Instructor)
                 .WithMany(i => i.CourseSchedules)
                 .HasForeignKey(cs => cs.InstructorId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cs => cs.Classroom)
                 .WithMany(c => c.CourseSchedules)
                 .HasForeignKey(cs => cs.ClassroomId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            //Enrollment
            modelBuilder.Entity<Enrollment>(e =>
            {
                e.HasKey(en => en.EnrollmentId);
                e.Property(x => x.Grade).HasPrecision(5, 2);

                e.HasOne(en => en.Student)
                 .WithMany(s => s.Enrollments)
                 .HasForeignKey(en => en.StudentId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(en => en.Course)
                 .WithMany(c => c.Enrollments)
                 .HasForeignKey(en => en.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasIndex(en => new { en.StudentId, en.CourseId }).IsUnique();
            });

            //Assignment
            modelBuilder.Entity<Assignment>(e =>
            {
                e.HasKey(a => a.AssignmentId);
                e.Property(a => a.Title).IsRequired().HasMaxLength(200);
                e.Property(a => a.Description).HasMaxLength(1000);
                e.Property(a => a.DueDate).IsRequired();
                e.HasOne(a => a.Course)
                 .WithMany(c => c.Assignments)
                 .HasForeignKey(a => a.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            //Submission
            modelBuilder.Entity<Submission>(e =>
            {
                e.HasKey(su => su.SubmissionId);
                e.Property(su => su.SubmissionDate).IsRequired();
                e.Property(su => su.Grade).HasPrecision(5, 2);
                e.HasOne(su => su.Assignment)
                 .WithMany(a => a.Submissions)
                 .HasForeignKey(su => su.AssignmentId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(su => su.Student)
                 .WithMany(a => a.AssignmentSubmissions)
                    .HasForeignKey(su => su.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Exam
            modelBuilder.Entity<Exam>(e =>
            {
                e.HasKey(ex => ex.ExamId);
                e.Property(x => x.Type).IsRequired().HasMaxLength(50);
                e.Property(ex => ex.ExamDate).IsRequired();
                
                
                e.HasOne(ex => ex.Course)
                 .WithMany(c => c.Exams)
                 .HasForeignKey(ex => ex.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            //ExamResult
            modelBuilder.Entity<ExamResult>(e =>
            {
                e.HasKey(er => er.ExamResultId);
                e.Property(er => er.Score).HasPrecision(5, 2);
                e.HasOne(er => er.Exam)
                 .WithMany(ex => ex.ExamResults)
                 .HasForeignKey(er => er.ExamId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(er => er.Student)
                 .WithMany(s => s.ExamResults)
                 .HasForeignKey(er => er.StudentId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasIndex(er => new { er.StudentId, er.ExamId }).IsUnique();
            });

            //Library
            modelBuilder.Entity<Library>(e =>
            {
                e.HasKey(l => l.LibraryId);
                e.Property(l => l.Name).IsRequired().HasMaxLength(200);
                e.Property(l => l.Location).IsRequired().HasMaxLength(200);
            });

            //Book
            modelBuilder.Entity<Book>(e =>
            {
                e.HasKey(b => b.BookId);
                e.Property(b => b.Title).IsRequired().HasMaxLength(200);
                e.Property(b => b.Author).IsRequired().HasMaxLength(200);
                e.Property(b => b.ISBN).IsRequired().HasMaxLength(20);
                
                e.HasOne(b => b.Library)
                 .WithMany(l => l.Books)
                 .HasForeignKey(b => b.LibraryId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasIndex(b => b.ISBN).IsUnique();
            });

            //BookLoan
            modelBuilder.Entity<BookLoan>(e =>
            {
                e.HasKey(bl => bl.LoanId);
                e.Property(bl => bl.LoanDate).IsRequired();
                e.Property(bl => bl.ReturnDate);
                e.HasOne(bl => bl.Book)
                 .WithMany(b => b.BookLoans)
                 .HasForeignKey(bl => bl.BookId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(bl => bl.Student)
                 .WithMany(s => s.BookLoans)
                 .HasForeignKey(bl => bl.StudentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
