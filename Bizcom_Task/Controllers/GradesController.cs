﻿using Bizcom_Task.Entities.DTO.Grade;
using Bizcom_Task.Entities.Model.Enum;
using Bizcom_Task.Service.ServiceContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom_Task.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade( [FromBody] AddGradeDTO addGrade)
        {
            try
            {
                await _gradeService.AddGrade(User, addGrade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetGradeById(int studentId)
        {
            try
            {
                var grade = await _gradeService.GetGradeById(studentId);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _gradeService.GetAllGrades();
            return Ok(grades);
        }
    }
}
