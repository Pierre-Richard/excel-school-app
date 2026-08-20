using System;
using excel_school_app.Enums;
using excel_school_app.Models;

namespace excel_school_app.Repository.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsersByRole(UserRole role);
    }
}
