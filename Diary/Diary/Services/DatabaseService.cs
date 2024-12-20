using Microsoft.EntityFrameworkCore;  
using Diary.Data; 


public class DatabaseService : IDatabaseService
{
    private readonly ApplicationDbContext _context;

    public DatabaseService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Вставка пользователя
    public async Task InsertUserAsync(User user)
    {
        user.Username = user.FirstName;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    // Вставка студента
    public async Task InsertStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    // Вставка преподавателя
    public async Task InsertTeacherAsync(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
    }

    // Вставка администратора
    public async Task InsertAdminAsync(Administrator admin){
        _context.Administrators.Add(admin);
        await _context.SaveChangesAsync();
    }
}
