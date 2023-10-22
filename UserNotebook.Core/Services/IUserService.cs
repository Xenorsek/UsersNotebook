using UserNotebook.Core.Models;
using UsersNotebook.Core.Models;

namespace UserNotebook.Core.Services
{
    public interface IUserService
    {
        Task CreateUser(CreateUserRequest newUser);
        Task DeleteUser(int id);
        Task<List<UserDto>> GetUsers();
        Task UpdateUser(UpdateUserRequest updateUser);
    }
}