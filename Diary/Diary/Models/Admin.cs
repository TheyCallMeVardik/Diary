using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Администраторы.
/// </summary>
public partial class Admin
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
