using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.Model
{
    public class Grade
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        [ForeignKey(nameof(studentId))]
        public virtual Student? Student { get; set; }
        public int teacherId { get; set; }
        [ForeignKey(nameof(teacherId))]
        public virtual Teacher? Teacher { get; set; }
        public int subjectId { get; set; }
        [ForeignKey(nameof(subjectId))]
        public virtual Subject? Subject { get; set; }
        public Decimal Score { get; set; }
    }
}
