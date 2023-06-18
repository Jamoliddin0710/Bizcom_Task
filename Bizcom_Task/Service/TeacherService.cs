

using Bizcom_Task.Entities.DTO.Teacher;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Exceptions;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Entities.Exceptions;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bizcom_Task.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task DeleteTeacher(int teacherId)
        {
            var teacher = await teacherRepository.GetTeacherById(teacherId);
            if (teacher is null)
                throw new EntityNotFoundException<Teacher>();

            await teacherRepository.DeleteTeacher(teacher);
        }

        public async Task EditProfile(ClaimsPrincipal claims, UpdateTeacherDTO updateUser)
        {
            int teacherId;
            try
            {
                teacherId = int.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = teacherRepository.GetTeacherById(teacherId).Result;

                var config = new TypeAdapterConfig();
                config.ForType<UpdateTeacherDTO, Teacher>()
                      .IgnoreNullValues(true)
                      .BeforeMapping((src, dest) =>
                      {
                          dest.Id = user.Id;
                          dest.Role = user.Role;
                      });

                var userUpdate = updateUser.Adapt(user, config);
                 teacherRepository.UpdateTeacher(userUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TeacherDTO>> GetAllTeachers()
        {
            var teachers = await teacherRepository.GetAllTeachers();
            return teachers.Adapt<List<TeacherDTO>>();
        }

        public async Task<TeacherDTO> GetTeacherById(int teacherId)
        {
            var teacher = await teacherRepository.GetTeacherById(teacherId);
            if (teacher is null)
                throw new EntityNotFoundException<Teacher>();
            return teacher.Adapt<TeacherDTO>();
        }

        public async Task<TeacherDTO> Profile(ClaimsPrincipal claims)
        {
            try
            {
                int teacherId = int.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var teacher = await teacherRepository.GetTeacherById(teacherId);
                return teacher.Adapt<TeacherDTO>();
            }
            catch (Exception ex)
            {
                throw new NotRegisteredException<Teacher>();
            }
        }

        public async Task<UserAuthInfo> SignIn(byte[] key, string phone, string password)
        {
            var user = await teacherRepository.SignInUser(phone, password);
            if (user is null)
                throw new EntityNotFoundException<Teacher>();

            var userAuth = GenerateToken(key, user);

            if (userAuth.UserCredentials is null)
                throw new EntityNullException<UserDTO>();
            return userAuth;

        }

        public async Task<UserAuthInfo> SignUp(byte[] key, CreateTeacherDTO createUser)
        {

            var teacher = createUser.Adapt<Teacher>();
            teacher.Role = Entities.Model.Enum.EUserRole.Teacher;
            await teacherRepository.SignUpUser(teacher);
            var userAuth = GenerateToken(key, teacher);
            if (userAuth.UserCredentials is null)
                throw new EntityNullException<UserDTO>();
            return userAuth;
        }

        public async Task UpdateTeacher(int teacherId, UpdateTeacherDTO updateTeacher)
        {
            var teacher = await teacherRepository.GetTeacherById(teacherId);
            if (teacher is null)
                throw new EntityNotFoundException<Teacher>();

            var config = new TypeAdapterConfig();
            config.ForType<UpdateTeacherDTO, Teacher>()
                  .IgnoreNullValues(true)
                  .BeforeMapping((src, dest) =>
                  {
                      dest.Id = teacher.Id;
                      dest.Email = teacher.Email;
                      dest.Role = teacher.Role;
                  });

            var teacherUpdate = updateTeacher.Adapt(teacher, config);
            await teacherRepository.UpdateTeacher(teacher);
        }

        private UserAuthInfo GenerateToken(byte[] key, Teacher teacher)
        {
            var tokendesc = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity
                (
                    new List<Claim>
                    {
                           new Claim(ClaimTypes.NameIdentifier , teacher.Id.ToString()),
                           new Claim(ClaimTypes.GivenName , teacher.FirstName),
                           new Claim(ClaimTypes.Role, teacher.Role.ToString()),
                           new Claim(ClaimTypes.CookiePath , teacher.Password),
                           new Claim(ClaimTypes.Email,  teacher.Email),
                    }

                ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokendesc);

            var authInfo = new UserAuthInfo()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserCredentials = teacher.Adapt<UserDTO>(),
            };
            if (string.IsNullOrEmpty(authInfo.Token))
                throw new EntityUnotharizeException<Teacher>();
            return authInfo;
        }
    }
}
