using Frontend.Entities.Model.Enum;
using Frontend.Entities.Model;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.Teacher
{
    public class CreateTeacherDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public List<TeacherSubjectDTO>? TeacherSubjectDTOs { get; set; }
    }
}
