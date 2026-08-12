using System;
using excel_school_app.Services.Classes;
using Microsoft.AspNetCore.Mvc;

namespace excel_school_app.Controllers
{
    [ApiController]
    [Route("api/class")]
    public class ClassController: ControllerBase
    {
        private readonly IClassService _classService;

        public  ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public IActionResult GetAllClasses()
        {
            try
            {
                var classes = _classService.GetAllClasses();
                return Ok(classes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
