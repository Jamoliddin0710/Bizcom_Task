using Bizcom_Task.Entities.Model.Enum;
using Bizcom_Task.Entities.Model;

namespace Bizcom_Task.Entities.ModelView
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public ETeacherStatus TeacherStatus { get; set; }
        public List<SubjectTeacherDTO>? SubjectTeacherDTOs { get; set; }
    }
}
