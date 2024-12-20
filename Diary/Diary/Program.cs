using Microsoft.EntityFrameworkCore;
using Diary.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Настройка DbContext с использованием PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// Добавление остальных сервисов, включая DatabaseService
builder.Services.AddScoped<IDatabaseService, DatabaseService>(); // Используем , потому что DbContext должен быть 

// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Используем среду разработки или продакшн для обработки ошибок
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
