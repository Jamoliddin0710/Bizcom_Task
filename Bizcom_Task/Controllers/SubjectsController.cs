using Bizcom_Task.Entities.DTO.Student;
using Bizcom_Task.Entities.DTO.Subject;
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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [ProducesResponseType(typeof(SubjectDTO), StatusCodes.Status200OK)]
        [HttpPost(Name = "Create-Subject")]
        public async Task<ActionResult<SubjectDTO>> CreateSubject(CreateSubjectDTO createSubject)
        => Ok(await subjectService.CreateSubject(createSubject));

        [ProducesResponseType(typeof(SubjectDTO), StatusCodes.Status200OK)]
        [HttpGet("{subjectId:int}", Name = "Get-Subject")]
        public async Task<ActionResult<SubjectDTO>> GetSubjectById(int subjectId)
        => Ok(await subjectService.GetSubjectById(subjectId));

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{subjectId:int}", Name = "Update-Subject")]
        public async Task<IActionResult> UpdateSubject(int subjectId, UpdateSubjectDTO updateSubject)
        {
            await subjectService.UpdateSubject(subjectId, updateSubject);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = "Delete-Subject")]
        public async Task<IActionResult> DeleteSubject(int subjectId)
        {
            await subjectService.DeleteSubject(subjectId);
            return NoContent();
        }

        [ProducesResponseType(typeof(List<SubjectDTO>), StatusCodes.Status200OK)]
        [HttpGet(Name = "Get-All")]
        public async Task<ActionResult<List<SubjectDTO>>> GetAllSubject()
        => Ok(await subjectService.GetAllSubjects());
    }
}
