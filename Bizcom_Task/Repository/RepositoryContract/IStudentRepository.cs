using Bizcom_Task.Entities.Model;

namespace Bizcom_Task.Repository.RepositoryContract
{
    public interface IStudentRepository
    {
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);
        Task<Student> GetStudentById(int studentId);
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentByName(string studentName);
    }
}
