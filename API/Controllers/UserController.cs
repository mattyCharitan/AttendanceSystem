using AppServices.DTO;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Implementations;
using Repositories.Interfaces;
using Repositories.Modules;
using System.Data;

namespace API.Controllers
{

    public class UserController : AttendenceBaseController
    {
        IUserSerivce userService;

        public UserController(IUserSerivce userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<List<UserDTO>> GetAll()
        {
            return await userService.GetAll();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await userService.GetById(id);
        }

        [Authorize]
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await userService.Delete(id);
        }

        [HttpPost]

        public async Task<int> Create(UserDTO userDTO)
        {
            return await userService.Create(userDTO);
        }

        [Authorize]
        [HttpPut]
        public async Task<int> Update(int id, UserDTO userDTO)
        {
            return await userService.Update(id, userDTO);
        }

        //[HttpPost]

        //public async Task<int> CreateS(UserAccount userDTO)
        //{
        //    return await userRepo.Create(userDTO);
        //}




    }
}
