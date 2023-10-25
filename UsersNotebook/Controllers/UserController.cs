using Microsoft.AspNetCore.Mvc;
using UserNotebook.Core.Services;
using UsersNotebook.Core.Models;

namespace UsersNotebook.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IReportService _reportService;

        public UserController(IUserService userService, IReportService reportService)
		{
			_userService = userService;
            _reportService = reportService;
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

        [HttpGet]
        public async Task<IActionResult> GenerateUserReport()
        {
            var users = await _userService.GetUsers();
            var pdfReport = _reportService.GenerateUserReport(users);
            var formattedDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return File(pdfReport, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{formattedDateTime}.pdf");
        }
    }
}
