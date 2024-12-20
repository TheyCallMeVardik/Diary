using Microsoft.EntityFrameworkCore;  
using Diary.Data; 


public interface IDatabaseService
{
    // Вставка пользователя
    Task InsertUserAsync(User user);

    // Вставка студента
    Task InsertStudentAsync(Student student);

    Task InsertTeacherAsync(Teacher teacher);

    Task InsertAdminAsync(Administrator admin);
}
