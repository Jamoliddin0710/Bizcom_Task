using Bizcom_Task.Entities.Model.Enum;

namespace Bizcom_Task.Entities.ModelView
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid StudentRegNumber { get; set; }
        public EStudentStatus StudentStatus { get; set; }
        public List<StudetTeacherDTO>? StudetTeachersDTOs { get; set; }
        public List<StudentSubjectDTO>? StudentSubjectDTOs { get; set; }
    }
}
