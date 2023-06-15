using Bizcom_Task.Entities.Model.Enum;
using Bizcom_Task.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.ModelView
{
    public class GradeDTo
    {
        public int Id { get; set; }
        public TeacherDTO TeacherDTO { get; set; }
        public StudentDTO? StudentDTO { get; set; }
        public int subjectId { get; set; }
        [ForeignKey(nameof(subjectId))]
        public virtual SubjectDTO? SubjectDTO { get; set; }
        public Decimal ScoreDTO { get; set; }
    }
}
