using Microsoft.EntityFrameworkCore;

namespace Diary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet для сущности User
        public DbSet<User> Users { get; set; }
        
        // DbSet для сущности Student
        public DbSet<Student> Students { get; set; }
        
        // DbSet для сущности Teacher
        public DbSet<Teacher> Teachers { get; set; }
        
        // DbSet для сущности Administrator
        public DbSet<Administrator> Administrators { get; set; }
        
    }
}
