using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Subject
{
    public class CreateSubjectDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
