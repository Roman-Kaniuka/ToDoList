namespace ToDoList.DAL.Interfaces;
//TODO: #11 Створюємо базовий репозиторій в якому будуть всі CRUD операції
public interface IBaseRepository<T>
{
    Task Create(T entity);
    // метод GetAll() буде повертати колекцію об'єктів або 1 об'єкт
    IQueryable<T> GetAll(); 
    Task Delete(T entit);
    Task<T> Update(T entity);
}