using System.ComponentModel.DataAnnotations;

namespace Frontend.Entities.DTO.Subject
{
    public class UpdateSubjectDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
