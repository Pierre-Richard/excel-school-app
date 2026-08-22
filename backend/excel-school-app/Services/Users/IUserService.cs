using System;
using excel_school_app.DTOs.Users;
using excel_school_app.Enums;

namespace excel_school_app.Services.Users
{
    public  interface IUserService
    {
          Task<IEnumerable<UserDto>>  GetStudents();
      
    }
}
