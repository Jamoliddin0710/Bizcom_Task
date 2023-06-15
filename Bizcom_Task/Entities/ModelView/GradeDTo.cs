using Bizcom_Task.Entities.Model.Enum;
using Bizcom_Task.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizcom_Task.Entities.ModelView
{
    public class GradeDTo
    {
        public int Id { get; set; }
        public TeacherDTO? TeacherDTO { get; set; }
        public StudentDTO? StudentDTO { get; set; }
        public string SubjectName { get; set; }
        public Decimal? Score { get; set; }
    }
}
