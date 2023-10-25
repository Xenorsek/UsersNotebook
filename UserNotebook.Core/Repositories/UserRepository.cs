using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using UserNotebook.Core.Exceptions;
using UsersNotebook.Data.Context;
using UsersNotebook.Data.Entities;

namespace UserNotebook.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _dbContext.Users.AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task CreateUser(User user)
        {
            if (!ValidateModel(user))
            {
                throw new ValidationException("Validation error");
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }
            if (!ValidateModel(updatedUser))
            {
                throw new ValidationException("Validation error");
            }

            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == updatedUser.Id);
            if (existingUser == null)
            {
                throw new NotFoundException(nameof(User), updatedUser.Id);
            }

            existingUser.Imie = updatedUser.Imie;
            existingUser.Nazwisko = updatedUser.Nazwisko;
            existingUser.DataUrodzenia = updatedUser.DataUrodzenia;
            existingUser.Plec = updatedUser.Plec;
            existingUser.DodatkoweParametry = JsonSerializer.Serialize(updatedUser.DodatkoweParametryList);

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveUserById(int id)
        {
            if (id <= 0)
            {
                throw new NotFoundException(nameof(User), id);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        private static bool ValidateModel(User user)
        {
            if (user == null)
                return false;
            if (string.IsNullOrEmpty(user.Imie))
                return false;
            if (string.IsNullOrEmpty(user.Nazwisko))
                return false;
            if (string.IsNullOrEmpty(user.Plec))
                return false;
            if (user.DataUrodzenia > DateTime.Now)
                return false;
            return true;
        }
    }
}
