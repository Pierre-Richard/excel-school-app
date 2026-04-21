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
        public IActionResult GetAllGrades()
        {
            try
            {
                var grades = _gradeService.GetAllGrades();
                return Ok(grades);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public IActionResult CreateGrade([FromBody] CreateGradeDto grade)
        {
            try
            {
                var newGrade = _gradeService.CreateGrade(grade);
                return Ok(newGrade);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGrade(int id)
        {
            try
            {
                _gradeService.DeleteGrade(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGrade(int id, [FromBody] UpdateGradeDto grade)
        {
            try
            {
                var newGrade = _gradeService.UpdateGrade(id, grade);
                return Ok(newGrade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
         
         public IActionResult GetGradeById(int id)
        {
            try
            {
                var grade = _gradeService.GetGradeById(id);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

    }

  
     

}
