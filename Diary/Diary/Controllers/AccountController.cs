using Microsoft.AspNetCore.Mvc;
using Diary.Models;

public class AccountController : Controller
{
    private readonly IDatabaseService _databaseService;

    public AccountController(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    // GET: /Account/Register
    public IActionResult Register()
    {
        return View(); 
    }

    // POST: /Account/Register
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (true /*Проврека телефона и пароля*/)
        {
            // Создаем запись в таблице users
            var user = new User
            {
                Username = $"{model.FirstName}{model.LastName}",
                Password = model.Password, 
                Role = model.Role, 
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                PhoneNumber = model.PhoneNumber
            };

            await _databaseService.InsertUserAsync(user);

            // Получаем UserId, чтобы вставить его в таблицу students
            long userId = user.UserId; 

            if(user.Role == "student")
            {
                var student = new Student
            {
                UserId = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                PhoneNumber = model.PhoneNumber,
                Username = user.Username,
                Password = user.Password,
                ClassId = long.Parse(model.SelectedClassKey)
            };

            await _databaseService.InsertStudentAsync(student);
            }else if(user.Role == "teacher")
            {
                var teacher = new Teacher
                {
                UserId = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                PhoneNumber = model.PhoneNumber,
                Username = user.Username,
                Password = user.Password
                };
                await _databaseService.InsertTeacherAsync(teacher);
            }else if(user.Role == "admin")
            {
                var admin = new Administrator
                {
                UserId = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                PhoneNumber = model.PhoneNumber,
                Username = user.Username,
                Password = user.Password
                };
                await _databaseService.InsertAdminAsync(admin);
            }
            return RedirectToAction("Index", "Home"); 
        }
    }
}
