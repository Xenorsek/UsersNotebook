using UserNotebook.Core.Models;

namespace UserNotebook.Core.Services
{
    public interface IUserService
    {
        Task DeleteUser(int id);
        Task<List<UserDto>> GetUsers();
    }
}