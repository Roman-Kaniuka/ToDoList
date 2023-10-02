using ToDoListDomain.Enum;

namespace ToDoListDomain.Filters.Task;
//TODO: #27 Створюємо клас який буде представляти собою параметри по яким буде відбуватися фільтарція даних
public class TaskFilter
{
    //може не обовязково вказуватись користувачем але це не значемий тип тому без "?" може бути "null"
    public string Name { get; set; }
    //Для Enum (значемий тип) треба поставити "?" тому що може бути "null"
    public Priority Priority { get; set; }
}