using Bizcom_Task.Entities.DTO.User;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Filters;
using Bizcom_Task.Service.ServiceContract;
using Entities.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace Bizcom_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IOptions<AppSettings> options;
        public AccountController(IUserService userService, IOptions<AppSettings> options)
        {
            this.userService = userService;
            this.options = options;
        }

        [ProducesResponseType(typeof(UserAuthInfo), StatusCodes.Status200OK)]
        [HttpPost("register", Name = "Register")]
        public async Task<ActionResult<UserAuthInfo>> SignUp([FromForm] CreateUserDTO createUser)
        {
            var key = Encoding.UTF8.GetBytes(options.Value.SecretKey);
            var userAuth = await userService.SignUp(key, createUser);
            return Ok(userAuth);
        }

        [ProducesResponseType(typeof(UserAuthInfo), StatusCodes.Status200OK)]
        [HttpPost("login", Name = "Login")]
        public async Task<ActionResult<UserAuthInfo>> SingIn([FromForm] LoginUserDTO loginUser)
        {
            var key = Encoding.UTF8.GetBytes(options.Value.SecretKey);
            var authInfo = await userService.SignIn(key, loginUser.Password, loginUser.Phone);
            return Ok(authInfo);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut(Name = "Edit-profile")]
        public async Task<IActionResult> EdetProfile([FromForm] UpdateUserDTO updateUser)
        {
            await userService.EditProfile(User, updateUser);
            return NoContent();
        }

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [HttpGet(Name = "Profile")]
        public async Task<ActionResult> Profile()
        => Ok(await userService.Profile(User));


    }
}
