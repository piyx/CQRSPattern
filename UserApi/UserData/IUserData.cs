using UserApi.Models;

namespace UserApi.UserData
{
    public interface IUserData
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<int> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
