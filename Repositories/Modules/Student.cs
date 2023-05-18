using System;
using System.Collections.Generic;

namespace Repositories.Modules;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public int? ParentId { get; set; }

    public virtual ICollection<MonthlyAttendance> MonthlyAttendances { get; set; } = new List<MonthlyAttendance>();

    public virtual UserAccount? Parent { get; set; }
}
