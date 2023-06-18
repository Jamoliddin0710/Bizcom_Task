using Bizcom_Task.Entities.Model;

namespace Bizcom_Task.Repository.RepositoryContract
{
    public interface ITeacherRepository
    {
        Task SignUpUser(Teacher teacher);
        Task<Teacher>? SignInUser(string phone, string password);
        Task UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(int teacherId);
        Task<List<Teacher>> GetAllTeachers();
    }
}
