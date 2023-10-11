using System.ComponentModel.DataAnnotations;

namespace ToDoListDomain.ViewModels.Task;


//TODO #41 Створюємо клас екземпляри якого будуть свторюватися під час повернення всіх виконаних задач. В майбутньому відрефакторити бо задвоєння коду 
public class TaskCompletedViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}