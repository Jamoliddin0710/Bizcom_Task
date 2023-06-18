using Bizcom_Task.Entities.Model.Enum;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.Model
{
    public class Teacher
    {
        [Column("teacherId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public EUserRole Role { get; set; } = EUserRole.Teacher;
        public ETeacherStatus TeacherStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<TeacherSubject>? TeacherSubjects { get; set; }
        public virtual ICollection<StudentTeacher>? StudentTeachers { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}
