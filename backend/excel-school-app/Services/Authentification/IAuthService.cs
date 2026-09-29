using System;
using excel_school_app.DTOs;

namespace excel_school_app.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto user);
        Task<AuthResponseDto> Login(LoginDto user);
    }
}
