﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UserNotebook.Core.Services;

namespace UsersNotebook.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
        public IActionResult UsersTable()
        {
            return PartialView();
        }

        public IActionResult AddUserForm()
        {
            return View();
        }
    }
}