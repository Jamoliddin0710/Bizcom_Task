using Bizcom_Task.Entities.DTO.Grade;
using Bizcom_Task.Entities.ModelView;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface IGradeService
    {
        Task AddGrade(int teacherId, AddGradeDTO addGrade);
        Task<GradeDTo> GetGradeById(int studentId);
        Task<List<GradeDTo>> GetAllGrades();
    }
}
