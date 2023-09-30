using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Service.Interfaces;
using ToDoListDomain.ViewModels.Task;

namespace ToDoList.Controllers;

public class
    TaskController : Controller //тут поміняли назву класу "TaskController" і вона автоматично змінилась в "Program.cs"
{
  
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

//створюємо новий метод дії !обов'язково вказуємо атрибут [HttpPost]!
    [HttpPost]
    //метод дії //Create() приймає параметр типу "CreateTaskViewModel" - це модель яка приймає дані з View 
    public async Task<IActionResult> Create(CreateTaskViewModel model)
    {
        //TODO: #15 переходим в "TaskController" щоб додати в метод дії,  дію з додаванням даних в БД
        // тепер буде викликатися метод "Create" в сервісі "TaskService" який додасть дані в БД та поверне екземпляр "BaseResponse"
        var response = await _taskService.Create(model);
        //якщо статус код "ОК" то ми записуємо в "description" інформацію яку в подальшому можна буде показати на сторінці
        if (response.StatusCode == ToDoListDomain.Enum.StatusCode.OK)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(new { description = response.Description });
    }
//TODO: #21 переходим в "TaskController" щоб додати в метод дії, дію з отриманням даних з БД
    [HttpPost]
    public async Task<IActionResult> TaskHandler()
    {
        var response = await _taskService.GetTasks();
        return Json(new { data = response.Date });
    }
    
}