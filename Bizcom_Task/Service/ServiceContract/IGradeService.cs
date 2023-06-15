using Bizcom_Task.Entities.DTO.Grade;
using Bizcom_Task.Entities.ModelView;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface IGradeService
    {
        Task AddGrade(AddGradeDTO addGrade);
        Task UpdateGrade();
        Task<GradeDTo> GetGradeById(int studentId);
    }
}
