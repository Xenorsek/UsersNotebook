using UsersNotebook.Data.Entities;

namespace UserNotebook.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task RemoveUserById(int id);
        Task UpdateUser(User updatedUser);
    }
}