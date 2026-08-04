using System;
using excel_school_app.Repository;
using excel_school_app.Services.Parents;
using Microsoft.AspNetCore.Mvc;

namespace excel_school_app.Controllers

{
    [ApiController]
    [Route("api/parent")]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        public IActionResult GetAllParents()
        {
            try
            {
                var parents = _parentService.GetAllParents();
                return Ok(parents);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
