using Frontend.Entities.ModelView;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.Student
{
    public class CreateStudentSubjectDTO
    {
        [Required]
        public int subjectId { get; set; }
    }
}
