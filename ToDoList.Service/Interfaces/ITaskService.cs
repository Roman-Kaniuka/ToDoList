using ToDoListDomain.Entity;
using ToDoListDomain.Response;
using ToDoListDomain.ViewModels.Task;

namespace ToDoList.Service.Interfaces;
//TODO: #8 Створюємо папку "Servise" з ВСІЄЮ логікою для роботи з базою та клієнтом 
//в назві інтерфейсу вказуэмо "I"+ назва об'єкта з яким працюємо "Таsk" + перефікс з "Service" або "repository" якщо це repository
public interface ITaskService
{
    //в "IBaseResponse<TaskEntity>" вказали "TaskEntity" це об'єкт який буде створюватись. Вхідний параметр буде об'єкт типу "CreateTaskViewModel"
    Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model); 
}

