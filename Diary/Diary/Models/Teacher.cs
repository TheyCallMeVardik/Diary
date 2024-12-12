using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Учителя
/// </summary>
public partial class Teacher
{
    public long TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
