using System;
using excel_school_app.DTOs.Users;
using excel_school_app.Enums;
using excel_school_app.Repository.Users;

namespace excel_school_app.Services.Users
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> GetStudents()
        {
            var users = await _userRepository.GetUsersByRole(UserRole.Student);
            return users.Select(u =>
            {
                return new UserDto
                {
                    Id = u.Id,
                    Email = u.Email,
                };
            });
        }


    }
}
