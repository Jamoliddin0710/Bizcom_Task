using Bizcom_Task.Entities.DTO.Teacher;
using Bizcom_Task.Entities.DTO.User;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Entities.DTO.User;
using Entities.Exceptions;
using Mapster;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Bizcom_Task.Exceptions;

namespace Bizcom_Task.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            this.userRepository = userRepository;
        }

        public async Task EditProfile(ClaimsPrincipal claims, UpdateUserDTO updateUser)
        {
            int userId;
            try
            {
                userId = int.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = userRepository.GetUserById(userId).Result;

                var config = new TypeAdapterConfig();
                config.ForType<UpdateUserDTO, User>()
                      .IgnoreNullValues(true)
                      .BeforeMapping((src, dest) =>
                      {
                          dest.Id = user.Id;
                          dest.Role = user.Role;
                      });

                var userUpdate = updateUser.Adapt(user, config);
                await userRepository.UpdateUser(userUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
   ;
        }

        public async Task<UserDTO> Profile(ClaimsPrincipal claims)
        {
            try
            {
                int userId = int.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = await userRepository.GetUserById(userId);
                return user.Adapt<UserDTO>();
            }
            catch (Exception ex)
            {
                throw new NotRegisteredException<User>();
            }
        }

        public async Task<UserAuthInfo> SignIn(byte[] key, string phone, string password)
        {
            var user = await userRepository.SignInUser(phone, password);
            if (user is null)
                throw new EntityNotFoundException<User>();

            var userAuth = GenerateToken(key, user);

            if (userAuth.UserCredentials is null)
                throw new EntityNullException<UserDTO>();
            return userAuth;

        }

        public async Task<UserAuthInfo> SignUp(byte[] key, CreateUserDTO createUser)
        {
            var user = createUser.Adapt<User>();
            user.Role = Entities.Model.Enum.EUserRole.Admin;
            await userRepository.SignUpUser(user);
            var userAuth = GenerateToken(key, user);
            if (userAuth.UserCredentials is null)
                throw new EntityNullException<UserDTO>();
            return userAuth;
        }

        private UserAuthInfo GenerateToken(byte[] key, User user)
        {
            var tokendesc = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity
                (
                    new List<Claim>
                    {
                           new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                           new Claim(ClaimTypes.GivenName , user.FirstName),
                           new Claim(ClaimTypes.Role, user.Role.ToString()),
                           new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                           new Claim(ClaimTypes.CookiePath , user.Password),
                           new Claim(ClaimTypes.Email, user.Email),
                    }

                ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokendesc);

            var authInfo = new UserAuthInfo()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserCredentials = user.Adapt<UserDTO>(),
            };
            if (string.IsNullOrEmpty(authInfo.Token))
                throw new EntityUnotharizeException<User>();
            return authInfo;
        }

    }
}
