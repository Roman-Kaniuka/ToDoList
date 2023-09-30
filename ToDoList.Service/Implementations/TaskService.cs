using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoList.DAL.Interfaces;
using ToDoList.Service.Interfaces;
using ToDoListDomain.Entity;
using ToDoListDomain.Enum;
using ToDoListDomain.Extenstions;
using ToDoListDomain.Response;
using ToDoListDomain.ViewModels.Task;

namespace ToDoList.Service.Implementations;
//TODO: #9 імплементуємомо (реалізуємо) інтерфейс
//TODO: #13 після кроку #12 продовжуємо реалізувати "ITaskService" метод "Create"


public class TaskService : ITaskService
{
    
    private readonly IBaseRepository<TaskEntity> _taskRepository;
    private ILogger<TaskService> _logger;

    public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
    {
        
        try
        {
            model.Validate();
            //перевіряємо чи є в таблиці завдання за сьогоднішній день зі схожою назвою
            _logger.LogInformation($"Запит на створення задачі - {model.Name}");
            var task = await _taskRepository.GetAll()
                .Where(x => x.Created.Date == DateTime.Today)
                .FirstOrDefaultAsync(x => x.Name == model.Name);
            //якщо в табличці є збіг і результат  != null то треба повідомити користувачу що він вже має схожу задачу яка була створена сьогодні
            if (task != null)
            {
                return new BaseResponse<TaskEntity>()
                {
                    Description = "Завдання з такою назвою вже створено",
                    StatusCode = StatusCode.TaskIsHasAlready
                };
            }
            
            //якщо все ОК то можна створювати об'єкт який в подальшому буде додано в БД
            task = new TaskEntity()
            {
                Name = model.Name,
                IsDone = false,
                Description = model.Description,
                Priority = model.Priority,
                Created = DateTime.Now
                
            };
            //викликаємо метод який додасть об'єкт "task" в базу
            await _taskRepository.Create(task);
            _logger.LogInformation($"Завдання створено  - ім'я завдання: {task.Name}; час: {task.Created}");
            
            //повертаємо інформацію про дію яка виконалась
            return new BaseResponse<TaskEntity>()
            {
                Description = "Завдання створено",
                StatusCode = StatusCode.OK
            };

        }
        // у випадку помилки ми перехватуємо неї
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[TaskService.Create()]-{ex.Message}");
            return new BaseResponse<TaskEntity>()
            {
                Description = $"{ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
//TODO: #23 імплементуємомо (реалізуємо) метод "GetTasks()"
    public async Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetTasks()
    {
        try
        {
            var tasks = await _taskRepository.GetAll()
                .Select(x => new TaskViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsDone = x.IsDone == true ? "Готово":"Не готово",
                    //значення з Enum "Priority" треба отримати з дісплея тому треба добавити розширяючий метод "GetDisplayName"
                    Priority = x.Priority.GetDisplayName(),
                    Created = x.Created.ToLongDateString()//розібратися що це за метод
                })
                .ToListAsync();
            return new BaseResponse<IEnumerable<TaskViewModel>>()
            {
                StatusCode = StatusCode.OK,
                Date = tasks
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[TaskService.Create()]-{ex.Message}");
            return new BaseResponse<IEnumerable<TaskViewModel>>()
            {
                Description = $"{ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}