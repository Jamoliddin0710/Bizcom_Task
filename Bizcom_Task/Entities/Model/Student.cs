using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.Model
{
    public class Student
    {
        [Column("studentId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid StudentRegNumber { get; set; }
        public EUserRole Role { get; set; } = EUserRole.Student;
        public EStudentStatus StudentStatus { get; set; }
        public virtual ICollection<StudentSubject>? StudentSubjects { get; set; }
        public virtual ICollection<StudentTeacher>? StudentTeachers { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
