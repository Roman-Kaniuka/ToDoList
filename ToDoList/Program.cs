using Microsoft.EntityFrameworkCore;
using ToDoList.DAL;
using ToDoList.DAL.Interfaces;
using ToDoList.DAL.Repositories;
using ToDoList.Service.Implementations;
using ToDoList.Service.Interfaces;
using ToDoListDomain.Entity;

var builder = WebApplication.CreateBuilder(args);

//додали NuGet пакет "RazorRuntime" для того щоб автоматично обновляти сторінку (не білдити зміни) та викликаємо метод ".AddRazorRuntimeCompilation()"
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//TODO: #14 треба зареєструвати "TaskRepository" та "TaskService" щоб все працювало
//метод "AddScoped" створює один екземпляр об'єкта для всього запиту.
builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

//отримуємо рядок підключення який ми прописали в appsettings.json
var connectionString = builder.Configuration.GetConnectionString(("MSSQL"));

//TODO: #4 Всатновлюємо звязок ASP.NET з класом контекста "AppDbContext"
//вказуємо який клас контекст ми будемо використовувати
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //викликаємо метод для підключення БД Sql. В цей метод потрібно передати рядок підключення (вона вказана в appsettings.json).
    options.UseSqlServer(connectionString);
});
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}"); //в "TaskController.cs" поміняли назву класа і тут автоматчно мінаяється також "controller=Task"

app.Run();