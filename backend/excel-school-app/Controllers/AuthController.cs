using System;
using excel_school_app.DTOs;
using excel_school_app.GlobalException;
using excel_school_app.Services;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Register([FromBody] RegisterDto user)

        { 
                var userRegister = await _authService.Register(user);
                return Ok(userRegister);  
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {

            var userLogin = await _authService.Login(user);
        
            return Ok(userLogin);  
        }
        
    }
}
