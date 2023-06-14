using Bizcom_Task.Entities.DTO.Student;
using Bizcom_Task.Entities.ModelView;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface IStudentService
    {
        Task<StudentDTO> AddStudent(CreateStudentDTO createStudent);
        Task UpdateStudent(int studentId,  UpdateStudentDTO updateStudent);
        Task DeleteStudent(int studentId);
        Task<StudentDTO> GetStudentById(int studentId);
        Task<List<StudentDTO>> GetAllStudents();
        Task<StudentDTO> GetStudentByName(string studentName);
    }
}
