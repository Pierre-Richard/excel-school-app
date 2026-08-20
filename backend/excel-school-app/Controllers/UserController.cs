using System;
using excel_school_app.Enums;
using excel_school_app.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace excel_school_app.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("students")]
         
         public  IActionResult GetStudents()
        {

            try
            {
                var users = _userService.GetStudents();
                return Ok(users);
            }   
            
            catch (Exception ex)
            {
                {
                            return BadRequest(ex.Message);
                }
            }
        }

    }
}
