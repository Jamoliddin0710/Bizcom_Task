using Bizcom_Task.Entities.DTO.Student;
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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [HttpPost(Name = "Add-Student")]
        public async Task<ActionResult<StudentDTO>> AddStudent([FromBody]CreateStudentDTO createStudent)
        {
            var student = await studentService.AddStudent(createStudent);
            return Ok(student);
        }

        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [HttpGet("{studentId:int}", Name = "Get-Student")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int studentId)
        {
            var student = await studentService.GetStudentById(studentId);
            return Ok(student);
        }

        [ProducesResponseType(typeof(List<StudentDTO>), StatusCodes.Status200OK)]
        [HttpGet(Name = "Get-All-Students")]
        public async Task<ActionResult> GetAllStudents()
        {
            var students = await studentService.GetAllStudents();
            return Ok(students);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{studentId:int}", Name = "Update-Student")]
        public async Task<IActionResult> UpdateStudent(int studentId, UpdateStudentDTO updateStudent)
        {
            await studentService.UpdateStudent(studentId, updateStudent);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = "Delete-Student")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            await studentService.DeleteStudent(studentId);
            return NoContent();
        }

    }
}
