namespace excel_school_app.Models
{
    public class User
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; } 
       public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
