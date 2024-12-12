using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Ученики.
/// </summary>
public partial class Student
{
    public long StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public long ClassId { get; set; }

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Gpa> Gpas { get; set; } = new List<Gpa>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
