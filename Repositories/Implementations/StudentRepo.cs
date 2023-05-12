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
    public class StudentRepo : IStudentRepo
    {
        AttendanceContext context;
        public StudentRepo(AttendanceContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(Student entity)
        {
            await context.Students.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.StudentId;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await context.Students.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            context.Students.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetAll()
        {
            return await context.Students
                .Include(s => s.Parent1)
                .Include(s => s.Parent2)
                .Include(s => s.MonthlyAttendances)
                .ToListAsync<Student>();      
        }

        public async Task<Student> GetById(int id)
        {
            return await context.Students
                .Include(s => s.Parent1)
                .Include(s => s.Parent2)
                .Include(s => s.MonthlyAttendances)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<int> Update(int id, Student entity)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
            {
                return 0;
            }

            student.StudentName = entity.StudentName;
            student.DateOfBirth = entity.DateOfBirth;
            student.Address = entity.Address;
            student.Parent1Id = entity.Parent1Id;
            student.Parent2Id = entity.Parent2Id;


            await context.SaveChangesAsync();
            return id;

        }
    }
}
