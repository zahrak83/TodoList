using Microsoft.AspNetCore.Mvc;

namespace WebToDoList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
                return RedirectToAction("Index", "ToDo");

            return RedirectToAction("Login", "Account");
        }
    }
}
