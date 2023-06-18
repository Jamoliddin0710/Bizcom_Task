using Frontend.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Entities.DTO.Grade
{
    public class AddGradeDTO
    {
        public int studentId { get; set; }
        public int subjectId { get; set; }
        public Decimal Score { get; set; }
    }
}
