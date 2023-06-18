using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.User
{
    public class LoginUserDTO
    {
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
