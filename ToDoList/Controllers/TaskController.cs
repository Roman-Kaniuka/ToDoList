using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers;

public class TaskController : Controller //тут поміняли назву класу "TaskController" і вона автоматично змінилась в "Program.cs"
{
    public IActionResult Index()
    {
        return View();
    }
}