using System;
using excel_school_app.DTOs.absence;
using excel_school_app.Enums;
using excel_school_app.Services.absence;
using Microsoft.AspNetCore.Mvc;

namespace excel_school_app.Controllers
{

    [ApiController]
    [Route("api/absence")]
    public class AbsenceController : ControllerBase
    {

        private readonly IAbsenceService _absenceService;

        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }

        [HttpGet]
        public IActionResult GetAllAbsence()
        {
            try
            {
                var absence = _absenceService.GetAllAbsence();
                return Ok(absence);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateAbsence([FromBody] CreateAbsenceDto absence)
        {
            try
            {
                var newAbsence = _absenceService.CreateAbsence(absence);
                return Ok(newAbsence);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbsence(int id)
        {
            try
            {
                _absenceService.DeleteAbsence(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}/justify")]
        public IActionResult UpdateAbsence(int id, [FromBody] JustifyAbsenceDto absence)
        {
            try
            {
                var newAbsence = _absenceService.UpdateAbsence(id, absence);
                return Ok(newAbsence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAbsenceById(int id)
        {
            try
            {
                var absence = _absenceService.GetAbsenceById(id);
                return Ok(absence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")]
         public IActionResult GetFilteredAbsence(DateOnly? date, int? studentId, AbsenceStatus? status)
        {
            try
            {
                var filteredAbsence = _absenceService.GetFilteredAbsence(date,studentId,status);
                return Ok(filteredAbsence);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

    }

}
