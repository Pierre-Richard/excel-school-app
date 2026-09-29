using System;
using excel_school_app.DTOs.Grade;
using excel_school_app.Services.Grade;
using Microsoft.AspNetCore.Mvc;

namespace excel_school_app.Controllers
{

    [ApiController]
    [Route("api/grade")]

    // recevoir la requête, appeler le service, retourner la réponse.   
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)

        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            try
            {
                var grades = await _gradeService.GetAllGrades();
                return Ok(grades);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateGrade([FromBody] CreateGradeDto grade)
        {
            try
            {
                var newGrade = await _gradeService.CreateGrade(grade);
                return Ok(newGrade);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            try
            {
               await  _gradeService.DeleteGrade(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, [FromBody] UpdateGradeDto grade)
        {
            try
            {
                var newGrade = await _gradeService.UpdateGrade(id, grade);
                return Ok(newGrade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            try
            {
                var grade = await _gradeService.GetGradeById(id);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       [HttpGet("student/{studentId}")]
         public async Task<IActionResult> GetGradesByStudentId(int studentId)
        {
            try
            {
                var listGradeStudent = await _gradeService.GetGradesByStudentId(studentId);
                return Ok(listGradeStudent);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
       [HttpGet("student/{studentId}/average")]
         public async Task<IActionResult> GetAverageByStudentId(int studentId)
        {
            try
            {
                var listAverageStudent = await _gradeService.GetAverageByStudentId(studentId);
                return Ok(listAverageStudent);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
       [HttpGet("filter")]
         public async Task<IActionResult> GetFilteredGrades(int? studentId, Enums.Subject? subject, Enums.Term? term)
        {
            try
            {
                var filteredGradesStudent = await _gradeService.GetFilteredGrades(studentId,subject,term);
                return Ok(filteredGradesStudent);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

    }

  
     

}
