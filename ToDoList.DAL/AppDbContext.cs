using Microsoft.EntityFrameworkCore;
using ToDoListDomain.Entity;

namespace ToDoList.DAL;
//TODO: #3 Створюємо клас для роботи з базой даних
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base (options) //такий параметр конструктора потрібний в майбутньому для роботи з ASP.NET Core 
    {
        //прописуємо команду яка при першому запиту до БД буде створювати БД:) за допомогою метода .EnsureCreated()
        Database.EnsureCreated();
    }
    
    //прописуємо об'єкт який буде сущності в EF Core. Назва "Tasks" це і буде назва таблиці в БД
    public DbSet<TaskEntity> Tasks { get; set; }
}