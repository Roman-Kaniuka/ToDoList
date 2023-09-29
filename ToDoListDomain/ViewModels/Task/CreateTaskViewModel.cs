using ToDoListDomain.Enum;

namespace ToDoListDomain.ViewModels.Task;


//ця модель має зберігати всі необхідні властивості які будуть надсилатися для створення задачі
public class CreateTaskViewModel
{
    //ВАЖИЛВО! Назва елементів звідки передаються дані з файла "Index.cshtml" мають співпадати з властивостями моделі
    public string Name { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }

    //TODO: #17 Додаємо валідацію для перевірки чи заповнені всі поля
    public void Validate()
    {
        // перевіряємо чи дійсно поле пусте якщо так то кидаємо виключення
        if (string.IsNullOrWhiteSpace(Name))
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentNullException(Name, "Вкажіть назву задачі та її опис");
            }
            throw new ArgumentNullException(Name, "Вкажіть назву задачі");
            
        }
        if (string.IsNullOrWhiteSpace(Description))
        {
            throw new ArgumentNullException(Description, "Вкажіть опис завдання");
        }
    }
}