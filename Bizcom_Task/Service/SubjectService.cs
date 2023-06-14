using Bizcom_Task.Entities.DTO.Subject;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Entities.Exceptions;
using Mapster;

namespace Bizcom_Task.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public async Task<SubjectDTO> CreateSubject(CreateSubjectDTO createSubject)
        {
            var subject = createSubject.Adapt<Subject>();
            await subjectRepository.CreateSubject(subject);
            return subject.Adapt<SubjectDTO>();
        }

        public async Task DeleteSubject(int subjectId)
        {
            var subject = await subjectRepository.GetSubjectById(subjectId);
            if (subject is null)
                throw new EntityNotFoundException<Subject>();
            await subjectRepository.DeleteSubject(subject);
        }

        public async Task<List<SubjectDTO>> GetAllSubjects()
        {
            var subjects = await subjectRepository.GetAllSubjects();
            if (subjects is null || subjects.Count() == 0)
                return new List<SubjectDTO>();
            return subjects.Adapt<List<SubjectDTO>>();
        }

        public async Task<SubjectDTO> GetSubjectById(int subjectId)
        {
            var subject = await subjectRepository.GetSubjectById(subjectId);
            if (subject is null)
                throw new EntityNotFoundException<Subject>();
            return subject.Adapt<SubjectDTO>();
        }

        public async Task UpdateSubject(int subjectId, UpdateSubjectDTO updateSubjectDTO)
        {
            var subject = await subjectRepository.GetSubjectById(subjectId);
            
            if (subject is null)
                throw new EntityNotFoundException<Subject>();

            var config = new TypeAdapterConfig();
            config.ForType<UpdateSubjectDTO, Subject>()
                  .IgnoreNullValues(true)
                  .BeforeMapping((src, dest) =>
                  {
                      dest.Id = subject.Id;
                  });

            var subjectUpdate = updateSubjectDTO.Adapt(subject, config);
            await subjectRepository.UpdateSubject(subjectUpdate);
        }
    }
}
