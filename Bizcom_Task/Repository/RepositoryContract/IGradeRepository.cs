using Bizcom_Task.Entities.Model;

namespace Bizcom_Task.Repository.RepositoryContract
{
    public interface IGradeRepository
    {
        Task AddGrade(Grade grade);
        Task UpdateGrade(Grade grade);
        Task DeleteGrade(Grade grade);
        Task<Grade> GetGrade(int studentId);
        Task<List<Grade>> GetAllGrades();
    }
}
