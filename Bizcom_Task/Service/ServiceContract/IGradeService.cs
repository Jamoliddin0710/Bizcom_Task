using Bizcom_Task.Entities.DTO.Grade;
using Bizcom_Task.Entities.ModelView;
using System.Security.Claims;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface IGradeService
    {
        Task AddGrade(ClaimsPrincipal claims, AddGradeDTO addGrade);
        Task<GradeDTo> GetGradeById(int studentId);
        Task<List<GradeDTo>> GetAllGrades();
    }
}
