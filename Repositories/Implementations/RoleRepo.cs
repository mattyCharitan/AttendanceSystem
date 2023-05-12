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
    
        public class RoleRepo : IRoleRepo
        {
            AttendanceContext context;
            public RoleRepo(AttendanceContext context)
            {
                this.context = context;
            }
            public async Task<int> Create(UserRole entity)
            {
                await context.UserRoles.AddAsync(entity);
                await context.SaveChangesAsync();
                return (int)entity.Role;
            }

            public async Task<bool> Delete(int id)
            {
                var role = await context.UserRoles.FindAsync(id);

                if (role == null)
                {
                    return false;
                }

                context.UserRoles.Remove(role);
                await context.SaveChangesAsync();
                return true;
            }

            public async Task<List<UserRole>> GetAll()
            {
                return await context.UserRoles
                    .ToListAsync<UserRole>();
            }

            public async Task<UserRole> GetById(int id)
            {
                return await context.UserRoles
                    .FirstOrDefaultAsync(s => s.UserId == id);
            }

            public async Task<int> Update(int id, UserRole entity)
            {
                var user = await context.UserRoles.FindAsync(id);

                if (user == null)
                {
                    return 0;
                }
                user.Role = entity.Role;
                await context.SaveChangesAsync();
                return id;

            }
        }
    }

