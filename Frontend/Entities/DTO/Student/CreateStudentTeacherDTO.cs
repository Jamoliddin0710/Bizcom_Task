using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.Student
{
    public class CreateStudentTeacherDTO
    {
        [Required]
        public int teacherId { get; set; }
    }
}
