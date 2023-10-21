using System.ComponentModel.DataAnnotations;
using UserNotebook.Core.Models;
using UserNotebook.Core.Repositories;
using UsersNotebook.Core.Models;
using UsersNotebook.Data.Entities;

namespace UserNotebook.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var result = new List<UserDto>();
            var users = await _userRepository.GetUsers();
            result = users.Select(u => new UserDto
            {
                Id = u.Id,
                Imie = u.Imie,
                Nazwisko = u.Nazwisko,
                DataUrodzenia = u.DataUrodzenia,
                Plec = u.Płeć,
                DodatkoweParametry = u.DodatkoweParametryList.Select(dp => new AdditionalParametersDto { Key = dp.Key, Value = dp.Value }).ToList()
            }).ToList();

            return result;
        }

        public async Task CreateUser(CreateUserRequest newUser)
        {
            var isValid = ValidateParameters(newUser);
            if (!isValid)
            {
                throw new ValidationException("Nowy użytkownik nie przeszedł walidacji");
            }

            User user = new User
            {
                Imie = newUser.FirstName,
                Nazwisko = newUser.LastName,
                DataUrodzenia = newUser.BirthDate,
                Płeć = newUser.Gender,
            };
            user.DodatkoweParametryList = newUser.Parameters.Select(x => new AdditionalParameters { Key = x.Key, Value = x.Value }).ToList();

            await _userRepository.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.RemoveUserById(id);
        }

        private bool ValidateParameters(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(userRequest.FirstName) || userRequest.FirstName.Length > 50)
            {
                return false;
            }
            if(string.IsNullOrEmpty(userRequest.LastName) || userRequest.LastName.Length > 150)
            {
                return false;
            }
            if(userRequest.BirthDate > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
