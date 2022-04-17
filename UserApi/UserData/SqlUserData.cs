using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.UserData
{
    public class SqlUserData : IUserData
    {
        private UserContext _context;
        
        public SqlUserData(UserContext context)
        {
            _context = context;
        }
        
        public async Task<int> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
