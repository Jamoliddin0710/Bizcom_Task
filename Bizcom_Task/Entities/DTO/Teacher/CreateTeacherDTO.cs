using Bizcom_Task.Entities.Model.Enum;
using Bizcom_Task.Entities.Model;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Teacher
{
    public class CreateTeacherDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public List<TeacherSubjectDTO>? TeacherSubjectDTOs { get; set; }
    }
}
