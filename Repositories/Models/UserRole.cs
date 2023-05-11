using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class UserRole
{
    public int? UserId { get; set; }

    public int? Role { get; set; }

    public virtual UserAccount? User { get; set; }
}
