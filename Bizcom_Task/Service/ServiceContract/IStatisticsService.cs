using Bizcom_Task.Entities.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface IStatisticsService
    {
        Task<List<SubjectDTO>> GetAllStudentSubjectMaxScore(int studentId);
        Task<List<StudentDTO>> GetStudentAgeTo20();
        Task<List<StudentDTO>> GetStudentFrom12To18();
        Task<List<TeacherDTO>> GetTeacherFrom55();
        Task<Tuple<List<StudentDTO>, List<TeacherDTO>>> GetBeelinUser();
        Task<List<StudentDTO>> GetStudentByName(string name);
        Task<SubjectDTO> GetSubjectStudentBall(int studentId);
        Task<List<SubjectDTO>> GetStudentMaxScore10(int teacherId);
        Task<List<TeacherDTO>> GetTeacherByMaxScoreFrom97();
        Task<SubjectDTO> GetSubjectHighestAverageScore();
    }
}
