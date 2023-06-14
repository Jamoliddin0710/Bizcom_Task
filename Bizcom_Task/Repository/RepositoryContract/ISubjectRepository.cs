using Bizcom_Task.Entities.Model;

namespace Bizcom_Task.Repository.RepositoryContract
{
    public interface ISubjectRepository
    {
        Task CreateSubject(Subject subject);
        Task UpdateSubject(Subject subject);
        Task DeleteSubject(Subject subject);
        Task<Subject> GetSubjectById(int subjectId);
        Task<List<Subject>> GetAllSubjects();
    }
}
