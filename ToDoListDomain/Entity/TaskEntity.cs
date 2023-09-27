using ToDoListDomain.Enum;

namespace ToDoListDomain.Entity;
//сущность яка представляє собою "задачу" має влстивості
public class TaskEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
}
