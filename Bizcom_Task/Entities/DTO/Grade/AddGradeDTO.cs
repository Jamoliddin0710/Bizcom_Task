using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.DTO.Grade
{
    public class AddGradeDTO
    {
        public int studentId { get; set; }
        public int subjectId { get; set; }
        public EScore Score { get; set; }
    }
}
