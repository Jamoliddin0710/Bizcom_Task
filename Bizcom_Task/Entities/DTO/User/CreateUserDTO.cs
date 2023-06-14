using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.User
{
    public class CreateUserDTO
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
