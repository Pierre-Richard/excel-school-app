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

        [HttpGet]
         
         public  IActionResult GetUsersByRole([FromQuery] UserRole? role)
        {
            if(role is null) return  BadRequest("Le paramètre 'role' est requis.");
            try
            {
                var users = _userService.GetUsersByRole(role.Value);
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
