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
    }
}
