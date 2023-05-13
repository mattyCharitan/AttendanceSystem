﻿using System;
using System.Collections.Generic;

namespace Repositories.Modules;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Student> StudentParent1s { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentParent2s { get; set; } = new List<Student>();
}