using Microsoft.EntityFrameworkCore;
using ToDoList.DAL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//отримуємо рядок підключення який ми прописали в appsettings.json
var connectionString = builder.Configuration.GetConnectionString(("MSSQL"));

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