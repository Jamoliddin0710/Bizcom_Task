using Bizcom_Task.Entities.DTO.Subject;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.User
{
    public class UpdateUserDTO
    {
        public string? LastName { get; set; }
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        [Required]
        public List<CreateSubjectDTO>? Subjects { get; set; }
    }
}
