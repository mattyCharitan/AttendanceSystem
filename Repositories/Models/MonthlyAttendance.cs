using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class MonthlyAttendance
{
    public int AttendanceId { get; set; }

    public DateTime? Date { get; set; }

    public int? StudentId { get; set; }

    public string? Status { get; set; }

    public virtual Student? Student { get; set; }
}
