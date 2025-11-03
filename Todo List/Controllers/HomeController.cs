using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Todo_List.Models;
using Todo_List.Repositories;

namespace Todo_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoListRepo _todoService;

      
        public HomeController(ILogger<HomeController> logger, ITodoListRepo todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            var items = _todoService.GetAllListItems();
            return View(items);
        }
        [HttpPost]
        public IActionResult Add(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                bool result = _todoService.AddNewListItem(new TodoListItem { IsCompleted = false, Title = title });
                if (result)
                {
                   
                    TempData["Message"] = "Task Added successfully!";
                    TempData["Success"] = true;
                }
                else
                {
                    TempData["Message"] = "Make sure you enter the task!";
                    TempData["Success"] = false;
                }
            }
            else
            {
                TempData["Message"] = "Make sure you enter the task!";
                TempData["Success"] = false;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Toggle(int id)
        {
          bool result=  _todoService.ToggleItem(id);
            if (result)
            {
           
                TempData["Message"] = "Task Toggled successfully!";
                TempData["Success"] = true;
            }
            else
            {
               
                TempData["Message"] = "Task Not Found!";
                TempData["Success"] = false;
            }

            return RedirectToAction("Index");
        }    [HttpPost]
        public IActionResult Delete(int id)
        {
          bool result=  _todoService.DeleteItem(id);
            if (result)
            {
               
                TempData["Message"] = "Task deleted successfully!";
                TempData["Success"] = true;
            }
            else
            {

                TempData["Message"] = "Task Not Found!";
                TempData["Success"] = false;
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
