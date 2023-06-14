using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Student
{
    public class CreateStudentTeacherDTO
    {
        [Required]
        public int teacherId { get; set; }
    }
}
