using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Services.Interfaces;

namespace VetCare_BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}