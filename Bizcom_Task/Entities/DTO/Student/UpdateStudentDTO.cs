using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Student
{
    public class UpdateStudentDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public EStudentStatus StudentStatus { get; set; }
    }
}
