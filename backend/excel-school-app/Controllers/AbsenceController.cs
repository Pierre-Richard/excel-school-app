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
        public async Task<IActionResult> GetAllAbsence()
        {
            try
            {
                var absence = await _absenceService.GetAllAbsence();
                return Ok(absence);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbsence([FromBody] CreateAbsenceDto absence)
        {
            try
            {
                var newAbsence = await _absenceService.CreateAbsence(absence);
                return Ok(newAbsence);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            try
            {
                await _absenceService.DeleteAbsence(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}/justify")]
        public async Task<IActionResult> UpdateAbsence(int id, [FromBody] JustifyAbsenceDto absence)
        {
            try
            {
                var newAbsence = await _absenceService.UpdateAbsence(id, absence);
                return Ok(newAbsence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAbsenceById(int id)
        {
            try
            {
                var absence = await _absenceService.GetAbsenceById(id);
                return Ok(absence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")]
         public async Task<IActionResult> GetFilteredAbsence(DateOnly? date, int? studentId, AbsenceStatus? status)
        {
            try
            {
                var filteredAbsence = await _absenceService.GetFilteredAbsence(date,studentId,status);
                return Ok(filteredAbsence);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

    }

}
