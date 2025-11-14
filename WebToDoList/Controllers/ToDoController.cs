using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.Contract.Service;
using ToDoList.Domain.Core.Dtos;
using ToDoList.Domain.Core.Enums;

namespace WebToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemService _todoService;
        private readonly ICategoryService _categoryService;

        public ToDoController(IToDoItemService todoService, ICategoryService categoryService)
        {
            _todoService = todoService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string? search, string? sort)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var items = _todoService.Filter(userId.Value, search, sort);

            ViewBag.Search = search;
            ViewBag.Sort = sort;

            return View(items);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateToDoItemDto model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            model.UserId = userId.Value;
            _todoService.AddItem(model);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id, ToDoStatus status)
        {
            _todoService.UpdateStatus(id, status);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _todoService.DeleteItem(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _todoService.GetItemById(id);
            if (item == null)
                return NotFound();

            ViewBag.Categories = _categoryService.GetAllCategories();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(ToDoItemDto model)
        {
            var updated = _todoService.UpdateStatus(model.Id, model.Status);
            return RedirectToAction("Index");
        }
    }
}
