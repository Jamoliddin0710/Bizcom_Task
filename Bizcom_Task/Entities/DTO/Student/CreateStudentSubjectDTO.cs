using Bizcom_Task.Entities.ModelView;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Student
{
    public class CreateStudentSubjectDTO
    {
        [Required]
        public int subjectId { get; set; }
    }
}
