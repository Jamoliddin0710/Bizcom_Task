using Bizcom_Task.Entities.DTO.Teacher;
using Bizcom_Task.Entities.DTO.User;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Filters;
using Bizcom_Task.Service.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public partial class TeachersController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [ProducesResponseType(typeof(TeacherDTO), StatusCodes.Status200OK)]
        [HttpGet("{teacherId:int}", Name = "Get-Teacher")]
        public async Task<ActionResult<TeacherDTO>> GetTeacherById(int teacherId)
        => Ok(await teacherService.GetTeacherById(teacherId));


        [ProducesResponseType(typeof(List<TeacherDTO>), StatusCodes.Status200OK)]
        [HttpGet(Name = "Get-All-Teachers")]
        public async Task<ActionResult<TeacherDTO>> GetAllTeaches()
        => Ok(await teacherService.GetAllTeachers());

        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut(Name = "Update-Teacher")]
        public async Task<IActionResult> UpdateTeacher(int teacherId, UpdateTeacherDTO updateTeacher)
        {
            await teacherService.UpdateTeacher(teacherId, updateTeacher);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = "Delete-Teacher")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            await teacherService.DeleteTeacher(teacherId);
            return NoContent();
        }
    }
}
