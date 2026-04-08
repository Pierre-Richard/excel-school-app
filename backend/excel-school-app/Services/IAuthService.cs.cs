using System;
using excel_school_app.DTOs;

namespace excel_school_app.Services
{
    public interface IAuthService
    {
        AuthResponseDto Register(RegisterDto user);
        AuthResponseDto Login(LoginDto user);
    }
}
