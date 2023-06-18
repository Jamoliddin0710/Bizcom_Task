using Frontend.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.Teacher
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
