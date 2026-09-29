using System;
using excel_school_app.Enums;
using excel_school_app.Models;

namespace excel_school_app.Repository.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersByRole(UserRole role);
        Task<User?> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
    }
}
