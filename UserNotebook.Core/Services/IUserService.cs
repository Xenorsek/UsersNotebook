﻿using UserNotebook.Core.Models;

namespace UserNotebook.Core.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
    }
}