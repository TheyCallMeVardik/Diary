using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Diary.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Gpa> Gpas { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=diary;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_pkey");

            entity.ToTable("admin", tb => tb.HasComment("Администраторы."));

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FirstName).HasColumnName("first name");
            entity.Property(e => e.LastName).HasColumnName("last name");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("schoolClasses_pkey");

            entity.ToTable("classes", tb => tb.HasComment("Классы."));

            entity.Property(e => e.ClassId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("class_id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.ClassName).HasColumnName("class name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Gpa).HasColumnName("GPA");
            entity.Property(e => e.Quantity)
                .HasPrecision(2)
                .HasColumnName("quantity");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.Classes)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("admin_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_id_fkey");
        });

        modelBuilder.Entity<Gpa>(entity =>
        {
            entity.HasKey(e => e.AverageId).HasName("average_grades_pkey");

            entity.ToTable("GPA", tb => tb.HasComment("Средний балл."));

            entity.Property(e => e.AverageId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("average_id");
            entity.Property(e => e.AverageGrade).HasColumnName("average_grade");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Term)
                .HasPrecision(1)
                .HasColumnName("term");

            entity.HasOne(d => d.Student).WithMany(p => p.Gpas)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_fkey");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("grades_pkey");

            entity.ToTable("grades", tb => tb.HasComment("Оценки."));

            entity.Property(e => e.GradeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("grade_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Grade1)
                .HasPrecision(1)
                .HasColumnName("grade");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("teacher_id_fkey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("students_pkey");

            entity.ToTable("students", tb => tb.HasComment("Ученики."));

            entity.Property(e => e.StudentId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("student_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.FirstName).HasColumnName("first name");
            entity.Property(e => e.LastName).HasColumnName("last name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone number");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_id_fkey");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subjects_pkey");

            entity.ToTable("subjects", tb => tb.HasComment("Школьные предметы."));

            entity.Property(e => e.SubjectId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("subject_id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.SubjectName).HasColumnName("subject_name");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("admin_id_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teachers_pkey");

            entity.ToTable("teachers", tb => tb.HasComment("Учителя"));

            entity.Property(e => e.TeacherId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("teacher_id");
            entity.Property(e => e.FirstName).HasColumnName("first name");
            entity.Property(e => e.LastName).HasColumnName("last name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone number");
            entity.Property(e => e.Subject).HasColumnName("subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
