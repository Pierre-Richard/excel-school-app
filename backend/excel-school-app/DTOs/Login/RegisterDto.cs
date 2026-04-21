using System;

namespace excel_school_app.DTOs
{
    public class RegisterDto
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public  Enums.UserRole Role  { get; set; } 
        
    }
}
