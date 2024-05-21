using Microsoft.AspNetCore.Mvc;
using TaskList.Models;
using System.Reflection.Metadata.Ecma335;

namespace TaskList.Controllers
{

    public class TaskItemController : Controller
    {
        public List<TaskItem> _tasks =
        [
            new TaskItem {Id=1, Description="Finalizar o projeto", Status=false, InitialDate=DateTime.Parse("2024-05-10")},
            new TaskItem {Id=2, Description="Entregar o formulário", Status=false, InitialDate=DateTime.Parse("2024-05-10")},
            new TaskItem {Id=3, Description="Ir ao mercado", Status=true, InitialDate=DateTime.Parse("2024-06-10"), EndDate=DateTime.Parse(("2024-06-10"))}
        ];

        public IActionResult Index()
        {
            return View(_tasks);
        }
        public IActionResult Done()
        {
            return View(_tasks.Where(task => task.Status == true).ToList()); 
        }
        public IActionResult ToDo()
        {
            return View(_tasks.Where(task => task.Status == false).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Description,Status,InitialDate")] TaskItem task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
                task.EndDate = null;

                _tasks.Add(task);
            }
            return RedirectToAction("Index");
        }

    }
}
