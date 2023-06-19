using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Teacher
{
    public class CreateTeacherDTO
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
