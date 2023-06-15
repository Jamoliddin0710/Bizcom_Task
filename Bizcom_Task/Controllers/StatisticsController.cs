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

        //1) 20 yoshgacha bo'lgan barcha talabalar ma'lumotlarini ko'rsatish
        [HttpGet("Student-AgeTo20")]
        public async Task<IActionResult> GetAgeTo20()
        => Ok(await statisticsService.GetStudentAgeTo20());

        //12-avgustdan 18-sentyabrgacha tugʻilgan barcha oʻquvchilarning maʼlumotlarini koʻrsatish
        [HttpGet("Student-Mont-August-September")]
        public async Task<IActionResult> GetStudent12AugustToSeptember()
        => Ok(await statisticsService.GetStudentFrom12To18());

        //3) 55 yoshdan oshgan barcha oʻqituvchilarning maʼlumotlarini koʻrsatish
        [HttpGet("Teacher-Age-Compare-55")]
        public async Task<IActionResult> GetTeacherFrom55()
        => Ok(await statisticsService.GetTeacherFrom55());

        //4) Beeline mobil raqamidan foydalangan holda barcha talabalar va o'qituvchilarning ma'lumotlarini ko'rsatish (kod 90 yoki 91
        [HttpGet("Beeline-Users")]
        public async Task<IActionResult> GetBeelineUsers()
        => Ok(await statisticsService.GetBeelinUser());

        //5) Ismi yoki familiyasida kiritilgan ibora bo'lgan barcha talabalarning ma'lumotlarini ko'rsatish
        [HttpGet("Get-User-By-Name")]
        public async Task<IActionResult> GetUserByName(string name)
        => Ok(await statisticsService.GetStudentByName(name));

        //6) Tanlangan talaba eng yuqori ball toʻplagan fanni koʻrsating
        [HttpGet("Get-Subject-By-Student-Ball")]
        public async Task<IActionResult> GetSubjectStudentBall(int studentId)
        => Ok(await statisticsService.GetSubjectStudentBall(studentId));

        //7) Tanlangan oʻqituvchi tomonidan oʻqitiladigan va 80 balldan yuqori ball olgan 10 nafar talaba boʻlgan fanni koʻrsating
        [HttpGet("Get-Subject-By-Student-MaxBall10")]
        public async Task<IActionResult> Get10SubjectsByStudentMaxBall(int teacherId)
        => Ok(await statisticsService.GetStudentMaxScore10(teacherId));

        // 8) Talabalarning eng yuqori balli 97 dan yuqori bo'lgan fanlardan dars beradigan o'qituvchilarni ko'rsatish
        [HttpGet("Get-Teacher-By-From-Ball-97")]
        public async Task<IActionResult> GetTeacherByFromBall97()
        => Ok(await statisticsService.GetTeacherByMaxScoreFrom97());

        //9) Talabaning o'rtacha bahosi eng yuqori bo'lgan fanni ko'rsating
        [HttpGet("Get-Subject-By-MaxScore")]
        public async Task<IActionResult> GetSubjectByMaxScore(int studentId)
        => Ok(await statisticsService.GetSubjectByStudentMaxBall(studentId));


    }
}
