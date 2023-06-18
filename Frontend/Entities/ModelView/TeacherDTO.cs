
using Frontend.Entities.Model.Enum;

namespace Frontend.Entities.ModelView
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public ETeacherStatus TeacherStatus { get; set; }
        // public List<SubjectTeacherDTO>? SubjectTeacherDTOs { get; set; }
    }
}
