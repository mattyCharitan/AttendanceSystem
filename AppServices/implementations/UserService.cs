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
    public class UserService : IUserSerivce
    {
        IUserRepo userRepo;

        public UserService(IUserRepo userRepo) 
        { 
            this.userRepo = userRepo;
        }
        public Task<int> Create(UserDTO entity)
        {
            UserAccount user  = Mapping.Mapper.Map<UserAccount>(entity);
            user.Password = "123";
            return userRepo.Create(user);
        }

        public Task<bool> Delete(int id)
        {
            return userRepo.Delete(id);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<UserAccount> users = await userRepo.GetAll();
            List<UserDTO> usersDtos = new List<UserDTO>();
            foreach (UserAccount user in users)
            {
                UserDTO userDTO = Mapping.Mapper.Map<UserDTO>(user);
                usersDtos.Add(userDTO);


            }
            return usersDtos;
        }

        public  async Task<UserDTO> GetById(int id)
        {
            UserAccount user = await userRepo.GetById(id);
            UserDTO userDTO = Mapping.Mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<int> Update(int id, UserDTO entity)
        {
            UserAccount user = Mapping.Mapper.Map<UserAccount>(entity);
            return await userRepo.Update(id, user);
        }
    }
}
