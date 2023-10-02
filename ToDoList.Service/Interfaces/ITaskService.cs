using ToDoListDomain.Entity;
using ToDoListDomain.Filters.Task;
using ToDoListDomain.Response;
using ToDoListDomain.ViewModels.Task;

namespace ToDoList.Service.Interfaces;
//TODO: #8 Створюємо папку "Servise" з ВСІЄЮ логікою для роботи з базою та клієнтом 
//в назві інтерфейсу вказуэмо "I"+ назва об'єкта з яким працюємо "Таsk" + перефікс з "Service" або "repository" якщо це repository
public interface ITaskService
{
    //в "IBaseResponse<TaskEntity>" вказали "TaskEntity" це об'єкт який буде створюватись. Вхідний параметр буде об'єкт типу "CreateTaskViewModel"
    Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model); 
    
    //TODO: #22 щоб зробити якусь логіку для роботи з БД потрібен метод в "Servise" тому прописуємо його тут а реалізуємо далі в класі
    //метод буде повертати колекцію даних типу "TaskViewModel"
    //TODO: #27 Для реалізації фільтрації даних треба додати параметр "TaskFilter" в метод "GetTasks"
    Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetTasks(TaskFilter filter); 
}

