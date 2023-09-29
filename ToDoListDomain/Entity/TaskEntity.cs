using ToDoListDomain.Enum;

namespace ToDoListDomain.Entity;
//TODO: #1 Створюємо сутність яка представляє собою "задачу" та має має влативості
public class TaskEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public Priority Priority { get; set; }
}
