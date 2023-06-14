using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.Model
{
    public class User
    {
        [Column("userId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public EUserRole Role { get; set; }
    }
}
