using Bizcom_Task.Entities.DTO.Subject;
using Bizcom_Task.Entities.DTO.Teacher;
using Bizcom_Task.Entities.ModelView;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface ITeacherService
    {
        Task<TeacherDTO> CreateTeacher(CreateTeacherDTO createTeacher);
        Task UpdateTeacher(int teacherId , UpdateTeacherDTO updateTeacher);
        Task DeleteTeacher(int teacherId);
        Task<TeacherDTO> GetTeacherById(int teacherId);
        Task<List<TeacherDTO>> GetAllTeachers();
    }
}
