using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Subject
{
    public class UpdateSubjectDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
