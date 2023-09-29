using ToDoList.DAL.Interfaces;
using ToDoListDomain.Entity;
namespace ToDoList.DAL.Repositories;
//TODO: #12 Реалізуємо інтерфейс "IBaseRepository<T>" Create/GetAll/Delete/Update
public class TaskRepository : IBaseRepository<TaskEntity>
{
    //створюємо об'єкт класу "AppDbContext"
    private readonly AppDbContext _appDbContext;

    public TaskRepository(AppDbContext appDbContext)
    {
        //присвоюємо значення для об'єкту класу
        _appDbContext = appDbContext;
    }
    
    //реалізуємо метод Create
    public async Task Create(TaskEntity entity)
    {
        //на об'єкті класу викликаємо конкретну сутність "Tasks" - це назва таблиці в БД і передаємо об'єкт який буде записано в таблицю БД
        await _appDbContext.Tasks.AddAsync(entity);
        //зберігаємо зміни які відбулися
        await _appDbContext.SaveChangesAsync();
    }
    
    //реалізуємо метод GetAll
    public IQueryable<TaskEntity> GetAll()
    {
        return _appDbContext.Tasks;
    }
    
    //реалізуємо метод Delete
    public async Task Delete(TaskEntity entity)
    {
        //викликаємо метод "Remove" в який передаємо об'єкт який буде видалено з табилці
        _appDbContext.Tasks.Remove(entity);
        //зберігаємо зміни які відбулися
        await _appDbContext.SaveChangesAsync();
    }
    
    public async Task<TaskEntity> Update(TaskEntity entity)
    {
        //викликаємо метод "Update" для оновлення даних
        _appDbContext.Tasks.Update(entity);
        //зберігаємо зміни які відбулися
        await _appDbContext.SaveChangesAsync();

        return entity;
    }
}