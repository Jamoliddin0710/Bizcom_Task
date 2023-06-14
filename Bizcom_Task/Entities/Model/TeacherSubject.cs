using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.Model
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int teacherId { get; set; }
        [ForeignKey(nameof(teacherId))]
        public Teacher? Teacher { get; set; }
        public int subjectId { get; set; }
        [ForeignKey(nameof(subjectId))]
        public Subject? Subject { get; set; }
    }
}
