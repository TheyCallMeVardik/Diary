using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Средний балл.
/// </summary>
public partial class Gpa
{
    public long AverageId { get; set; }

    public long StudentId { get; set; }

    public float AverageGrade { get; set; }

    public decimal Term { get; set; }

    public virtual Student Student { get; set; } = null!;
}
