using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Классы.
/// </summary>
public partial class Class
{
    public long ClassId { get; set; }

    public decimal Quantity { get; set; }

    public string ClassName { get; set; } = null!;

    public float Gpa { get; set; }

    public long TeacherId { get; set; }

    public long AdminId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Teacher Teacher { get; set; } = null!;
}
