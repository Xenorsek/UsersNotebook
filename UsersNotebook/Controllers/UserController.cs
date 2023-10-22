using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UserNotebook.Core.Services;
using UsersNotebook.Core.Models;
using UsersNotebook.Models;

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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] CreateUserRequest user)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserRequest user)
        {
            if(ModelState.IsValid)
            {
                await _userService.UpdateUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
