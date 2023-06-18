
using Bizcom_Task.Entities.DTO.Teacher;

using Bizcom_Task.Entities.ModelView;
using System.Net;
using System.Security.Claims;

namespace Bizcom_Task.Service.ServiceContract
{
    public interface IUserService
    {
        Task<UserAuthInfo> SignUp(byte[] key, CreateTeacherDTO createUser);
        Task<UserAuthInfo> SignIn(byte[] key, string phone, string password);
        Task<UserDTO> Profile(ClaimsPrincipal claims);
        Task EditProfile(ClaimsPrincipal claims, UpdateTeacherDTO updateUser);
    }
}
