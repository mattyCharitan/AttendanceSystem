using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class UserDTO
    {
        public string? Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
