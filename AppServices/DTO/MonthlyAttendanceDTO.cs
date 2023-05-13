using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class MonthlyAttendanceDTO
    {
        public int AttendanceId { get; set; }

        public DateTime? Date { get; set; }

        public int? StudentId { get; set; }

        public string? Status { get; set; }

    }
}
