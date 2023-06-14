using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Teacher
{
    public class UpdateTeacherDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public ETeacherStatus TeacherStatus { get; set; }
    }
}
