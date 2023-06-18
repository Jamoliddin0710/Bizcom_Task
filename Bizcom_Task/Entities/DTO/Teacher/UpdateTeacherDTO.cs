using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Teacher
{
    public class UpdateTeacherDTO
    {
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
