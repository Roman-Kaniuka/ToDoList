using ToDoListDomain.Enum;

namespace ToDoListDomain.Response;
//в усіх сервісів буде повертатися інтерфейс "IBaseResponse" який буде містити дані про дію яка відбулася і дженерік об'єкт в властивості "T Date".
//Наприклад: якщо завдання додалося => повертається об'єкт "BaseResponse" з: Description = "завдання створилося"; StatusCode = "ОК"; Date = об'єкт який створився => далі
//передається в контроллер => після передаємо клієнту який вже буде відображати або Date або Description
public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public T Date { get; set; }
}
//TODO: #10 Стовоюємо інтефейс який буде представляти собою об'єкт з інформацією про дію яка відбулася
public interface IBaseResponse<T>
{
    //опис дії яка відбулася
    string Description { get; } 
    //статус. Якщо помилка - то помилка і т.д.
    StatusCode StatusCode { get; set; }
    //властивість в яку можна зберегти як один об'єкт так і цілий список об'єктів
    T Date { get; }
}