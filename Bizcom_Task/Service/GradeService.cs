using Bizcom_Task.Entities.DTO.Grade;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Entities.Exceptions;
using Mapster;
using System.Security.Claims;

namespace Bizcom_Task.Service
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ISubjectRepository subjectRepository;
        public GradeService(IGradeRepository gradeRepository, ISubjectRepository subjectRepository, IStudentRepository studentRepository = null)
        {
            _gradeRepository = gradeRepository;
            this.subjectRepository = subjectRepository;
            this.studentRepository = studentRepository;
        }

        public async Task AddGrade(ClaimsPrincipal claims, AddGradeDTO addGrade)
        {
            int? teacherId;
            try
            {
                teacherId = int.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (Exception ex)
            {
                throw new NotRegisteredException<Teacher>();
            }
            // Mapping AddGradeDTO to Grade entity
            if (!_gradeRepository.IsThereStudentAndSubject(addGrade.studentId, addGrade.subjectId))
                throw new EntityNotFoundException<StudentSubject>();
            var grade = addGrade.Adapt<Grade>();
            grade.teacherId = teacherId.Value;
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
