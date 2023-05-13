using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class MonthlyAttendenceRepo : IMonthlyAttendenceRepo
    {
        AttendanceContext context;
        public MonthlyAttendenceRepo(AttendanceContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(MonthlyAttendance entity)
        {
            await context.MonthlyAttendances.AddAsync(entity);
            await context.SaveChangesAsync();
            return (int)entity.AttendanceId;
        }

        public async Task<bool> Delete(int id)
        {
            var monthly = await context.MonthlyAttendances.FindAsync(id);

            if (monthly == null)
            {
                return false;
            }

            context.MonthlyAttendances.Remove(monthly);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MonthlyAttendance>> GetAll()
        {
            return await context.MonthlyAttendances
                .ToListAsync<MonthlyAttendance>();
        }

        public async Task<MonthlyAttendance> GetById(int id)
        {
            return await context.MonthlyAttendances
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
        }

        public async Task<int> Update(int id, MonthlyAttendance entity)
        {
            var monthly = await context.MonthlyAttendances.FindAsync(id);

            if (monthly == null)
            {
                return 0;
            }
            monthly.Date = entity.Date;
            monthly.StudentId = entity.StudentId;
            //realtion
            monthly.Status = entity.Status;
            await context.SaveChangesAsync();
            return id;

        }
    }
}
