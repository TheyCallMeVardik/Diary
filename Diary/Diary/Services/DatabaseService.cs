using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Получить все классы
    public async Task<List<Class>> GetClassesAsync()
    {
        var classes = new List<Class>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var cmd = new NpgsqlCommand("SELECT * FROM public.classes", connection))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        classes.Add(new Class
                        {
                            ClassId = reader.GetInt64(reader.GetOrdinal("class_id")),
                            ClassName = reader.GetString(reader.GetOrdinal("class name")),
                            GPA = reader.GetDouble(reader.GetOrdinal("GPA")),
                            TeacherId = reader.GetInt64(reader.GetOrdinal("teacher_id")),
                            AdminId = reader.GetInt64(reader.GetOrdinal("admin_id")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"))
                        });
                    }
                }
            }
        }

        return classes;
    }

    // Вставить новый класс
    public async Task InsertClassAsync(Class newClass)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.classes (\"class name\", GPA, teacher_id, admin_id, created_at) VALUES (@class_name, @gpa, @teacher_id, @admin_id, @created_at)", connection))
            {
                cmd.Parameters.AddWithValue("class_name", newClass.ClassName);
                cmd.Parameters.AddWithValue("gpa", newClass.GPA);
                cmd.Parameters.AddWithValue("teacher_id", newClass.TeacherId);
                cmd.Parameters.AddWithValue("admin_id", newClass.AdminId);
                cmd.Parameters.AddWithValue("created_at", newClass.CreatedAt);

                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
