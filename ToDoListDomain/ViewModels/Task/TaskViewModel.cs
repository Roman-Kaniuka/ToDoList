using System.ComponentModel.DataAnnotations;
using ToDoListDomain.Enum;

namespace ToDoListDomain.ViewModels.Task;


//TODO: #23 Додаємо новий клас який буде описувати дані які будуть передаватися в табличку для відображення всіх "Завдань" з БД
public class TaskViewModel
{
    //для того щоб властивості відображалися не анг а укр ми додаємо атрибут [Display]
    public long Id { get; set; }
    
    [Display (Name ="Назва")]
    public string Name { get; set; }
    
    [Display (Name ="Готовність")]
    public string IsDone { get; set; }
    
    [Display (Name ="Опис")]
    public string Description { get; set; }
    
    [Display (Name ="Дата створення")]
    public string Created { get; set; }
    
    [Display (Name ="Пріоритет")]
    public string Priority { get; set; }
    
}