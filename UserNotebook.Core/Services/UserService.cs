using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotebook.Core.Models;
using UserNotebook.Core.Repositories;

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
    }
}
