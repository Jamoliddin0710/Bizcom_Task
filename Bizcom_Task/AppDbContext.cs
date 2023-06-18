using Bizcom_Task.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<TeacherSubject> TeachersSubjects { get; set; }
    }
}
