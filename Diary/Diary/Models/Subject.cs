using System;
using System.Collections.Generic;

namespace Diary.Models;

/// <summary>
/// Школьные предметы.
/// </summary>
public partial class Subject
{
    public long SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public long TeacherId { get; set; }

    public long StudentId { get; set; }

    public long AdminId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
