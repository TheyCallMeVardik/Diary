using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Оценки.
/// </summary>
public partial class Grade
{
    public long GradeId { get; set; }

    public long StudentId { get; set; }

    public decimal Grade1 { get; set; }

    public DateOnly Date { get; set; }

    public long? TeacherId { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; }
}
