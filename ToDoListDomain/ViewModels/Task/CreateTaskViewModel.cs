using ToDoListDomain.Enum;

namespace ToDoListDomain.ViewModels.Task;


//ця модель має зберігати всі необхідні властивості які будуть надсилатися для створення задачі
public class CreateTaskViewModel
{
    //ВАЖИЛВО! Назва елементів звідки передаються дані з файла "Index.cshtml" мають співпадати з властивостями моделі
    public string Name { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
}