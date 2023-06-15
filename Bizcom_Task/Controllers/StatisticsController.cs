using Bizcom_Task.Service.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet("Student-AgeTo20")]
        public async Task<IActionResult> GetAgeTo20()
        => Ok(await statisticsService.GetStudentAgeTo20());

        [HttpGet("Student-Mont-August-September")]
        public async Task<IActionResult> GetStudent12AugustToSeptember()
        => Ok(await statisticsService.GetStudentFrom12To18());

        [HttpGet("Teacher-Age-Compare-55")]
        public async Task<IActionResult> GetTeacherFrom55()
       => Ok(await statisticsService.GetTeacherFrom55());

        [HttpGet("Beeline-Users")]
        public async Task<IActionResult> GetBeelineUsers()
       => Ok(await statisticsService.GetBeelinUser());

        [HttpGet("Get-User-By-Name")]
        public async Task<IActionResult> GetUserByName(string name)
       => Ok(await statisticsService.GetStudentByName(name));

        //6) Tanlangan talaba eng yuqori ball toʻplagan fanni koʻrsating
        [HttpGet("Get-Subject-By-Student-Ball")]
        public async Task<IActionResult> GetSubjectStudentBall(int studentId)
     => Ok(await statisticsService.GetStudentByName("sd"));
    }
}
