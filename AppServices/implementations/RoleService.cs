using AppServices.DTO;
using AppServices.Interfaces;
using Repositories.Interfaces;
using Repositories.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.implementations
{
    public class RoleService : IRoleService
    {
        IRoleRepo roleRepo;

        public RoleService(IRoleRepo roleRepo)
        {
            this.roleRepo = roleRepo;
        }
        public Task<int> Create(RoleDTO entity)
        {
            UserRole role = Mapping.Mapper.Map<UserRole>(entity);
            return roleRepo.Create(role);

        }

        public Task<bool> Delete(int id)
        {
            return roleRepo.Delete(id);
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            List<UserRole> roles = await roleRepo.GetAll();
            List<RoleDTO> rolesDtos = new List<RoleDTO>();
            foreach (UserRole role in roles)
            {
                RoleDTO roleDTO = Mapping.Mapper.Map<RoleDTO>(role);
                rolesDtos.Add(roleDTO);
            }
            return rolesDtos;
        }

        public  async Task<RoleDTO> GetById(int id)
        {
            UserRole role = await roleRepo.GetById(id);
            RoleDTO roleDTO = Mapping.Mapper.Map<RoleDTO>(role);
            return roleDTO;

        }

        public async Task<int> Update(int id, RoleDTO entity)
        {
            UserRole role = Mapping.Mapper.Map<UserRole>(entity);
            return await roleRepo.Update(id, role);
        }
    }
}
