using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.Subject
{
    public class CreateSubjectDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
