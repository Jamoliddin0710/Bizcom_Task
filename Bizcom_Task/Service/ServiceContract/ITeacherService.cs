using Bizcom_Task.Entities.DTO.Subject;
using Bizcom_Task.Entities.DTO.Teacher;
using Bizcom_Task.Entities.ModelView;
using System.Security.Claims;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface ITeacherService
    {
        Task<UserAuthInfo> SignUp(byte[] key, CreateTeacherDTO createUser);
        Task<UserAuthInfo> SignIn(byte[] key, string phone, string password);
        Task<TeacherDTO> Profile(ClaimsPrincipal claims);
        Task EditProfile(ClaimsPrincipal claims, UpdateTeacherDTO updateUser);
        Task<List<TeacherDTO>> GetAllTeachers();
        Task<TeacherDTO> GetTeacherById(int teacherId);
        Task DeleteTeacher(int teacherId);
        Task UpdateTeacher(int teacherId, UpdateTeacherDTO updateTeacher);
    }
}
