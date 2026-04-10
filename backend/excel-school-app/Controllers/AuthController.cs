using System;
using excel_school_app.DTOs;
using excel_school_app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace excel_school_app.Controllers
{
    [ApiController]
    [Route("api/auth")]    

    // recevoir la requête, appeler le service, retourner la réponse.
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]

        public IActionResult Register([FromBody] RegisterDto user)

        {
            try
            {
                var userRegister = _authService.Register(user);
                return Ok(userRegister);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        
        public IActionResult Login([FromBody] LoginDto user)
        {
            try
            {
                var userLogin = _authService.Login(user);
                return Ok(userLogin);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
        
    }
}
