using System;
using excel_school_app.Data;
using excel_school_app.Enums;
using excel_school_app.Models;
using Microsoft.EntityFrameworkCore;

namespace excel_school_app.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<User>> GetUsersByRole(UserRole role)
        {
            // la liste filtrer des users qui on le role qu'on lui donnne
            var users = await _appDbContext.User.Where(u => u.Role == role).ToListAsync();

            return users;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User> CreateUser(User user)
        {
         

            _appDbContext.User.Add(user);
            await _appDbContext.SaveChangesAsync();

            return user;

        }
    }
    }
