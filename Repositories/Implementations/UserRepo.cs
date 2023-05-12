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
    public class UserRepo : IUserRepo
    {
        AttendanceContext context;
        public UserRepo(AttendanceContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(UserAccount entity)
        {
            await context.UserAccounts.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.UserId;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await context.UserAccounts.FindAsync(id);

            if (user == null)
            {
                return false;
            }

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
