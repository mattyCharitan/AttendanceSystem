using AppServices.DTO;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UserController : AttendenceBaseController
    {
        IUserSerivce userService;
        public UserController(IUserSerivce userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAll()
        {
            return await userService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await userService.GetById(id);
        }

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

        [HttpPut]

        public async Task<int> Update(int id, UserDTO userDTO)
        {
            return await userService.Update(id, userDTO);
        }
    }
}
