using Bizcom_Task.Entities.DTO.Subject;
using Bizcom_Task.Entities.ModelView;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface ISubjectService
    {
        Task<SubjectDTO> CreateSubject(CreateSubjectDTO createSubject);
        Task UpdateSubject(int subjectId, UpdateSubjectDTO updateSubjectDTO);
        Task DeleteSubject(int subjectId);
        Task<SubjectDTO> GetSubjectById(int subjectId);
        Task<List<SubjectDTO>> GetAllSubjects();
    }
}
