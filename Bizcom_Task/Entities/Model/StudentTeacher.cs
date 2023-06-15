using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.Model
{
    public class StudentTeacher
    {
        public int Id { get; set; }
        public int teacherId { get; set; }
        [ForeignKey(nameof(teacherId))]
        public virtual Teacher? Teacher { get; set; }
        public int studentId { get; set; }
        [ForeignKey(nameof(studentId))]
        public virtual Student? Student { get; set; }
    }
}
