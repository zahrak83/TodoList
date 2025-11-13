using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.Contract.Service;
using ToDoList.Domain.Core.Dtos;

namespace WebToDoList.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var user = _userService.Register(model);
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "ToDo");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string mobile, string password)
        {
            var user = _userService.Login(mobile, password);
            if (user == null)
            {
                ViewBag.Error = "شماره موبایل یا رمز عبور اشتباه است.";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
