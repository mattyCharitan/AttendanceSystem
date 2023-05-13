using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    internal class StudentDTO
    {
        public string? StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public int? Parent1Id { get; set; }

        public int? Parent2Id { get; set; }

    }
}
