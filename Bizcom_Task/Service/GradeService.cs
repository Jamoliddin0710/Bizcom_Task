using Bizcom_Task.Entities.DTO.Grade;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Mapster;

namespace Bizcom_Task.Service
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task AddGrade(int teacherId, AddGradeDTO addGrade)
        {
            // Mapping AddGradeDTO to Grade entity
            var grade = addGrade.Adapt<Grade>();
            grade.teacherId = teacherId;
            // Add the grade using the repository
            await _gradeRepository.AddGrade(grade);
        }

        public async Task<GradeDTo> GetGradeById(int studentId)
        {
            var grade = await _gradeRepository.GetGrade(studentId);

            if (grade is null)
                throw new Exception("student is not graded");

            var gradeDTO = grade.Adapt<GradeDTo>();
            return gradeDTO;
        }

        public async Task<List<GradeDTo>> GetAllGrades()
        {
            var grades = await _gradeRepository.GetAllGrades();

            var gradeDTOs = grades.Adapt<List<GradeDTo>>();
            return gradeDTOs;
        }
    }

}
