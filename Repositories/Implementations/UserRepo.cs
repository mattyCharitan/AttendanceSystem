using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        AttendanceContext context;
        IRoleRepo roleRepo;
        public UserRepo(AttendanceContext context, IRoleRepo roleRepo)
        {
            this.context = context;
            this.roleRepo = roleRepo;
        }
        public async Task<int> Create(UserAccount entity)
        {
            //entity.UserId = null;
            await context.UserAccounts.AddAsync(entity);
            await context.SaveChangesAsync();
            UserRole ur = new();
            ur.UserId = entity.UserId;
            ur.Role = 0;
            await roleRepo.Create(ur);
            return (int)entity.UserId;

        }
        

        public async Task<bool> Delete(int id)
        {
            var user = await context.UserAccounts.FindAsync(id);

            if (user == null)
            {
                return false;
            }
            //sould delet all its students 
            //sould delet its role
            context.UserAccounts.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserAccount>> GetAll()
        {
            return await context.UserAccounts
                //check if it should include
                .ToListAsync<UserAccount>();
        }

        public async Task<UserAccount> GetById(int id)
        {
            return await context.UserAccounts
                .FirstOrDefaultAsync(s => s.UserId == id);
        }

        public async Task<int> Update(int id, UserAccount entity)
        {
            var user = await context.UserAccounts.FindAsync(id);

            if (user == null)
            {
                return 0;
            }

            user.Name = entity.Name;
            user.Email = entity.Email;
            user.DateOfBirth = entity.DateOfBirth;
            user.Phone = entity.Phone;



            await context.SaveChangesAsync();
            return id;

        }
    }
}
