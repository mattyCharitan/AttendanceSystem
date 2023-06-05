using AppServices.DTO;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{

    public class MonthlyAttendanceController : AttendenceBaseController
    {
        IMonthlyAttendanceService monthlyAttendanceService;
        public MonthlyAttendanceController(IMonthlyAttendanceService monthlyAttendanceService)
        {
            this.monthlyAttendanceService = monthlyAttendanceService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<List<MonthlyAttendanceDTO>> GetAll()
        {
            return await monthlyAttendanceService.GetAll();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<MonthlyAttendanceDTO> Get(int id)
        {
            return await monthlyAttendanceService.GetById(id);
        }

        [Authorize]
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await monthlyAttendanceService.Delete(id);
        }

        [HttpPost]

        public async Task<int> Create(MonthlyAttendanceDTO monthlyAttendanceDTO)
        {
            return await monthlyAttendanceService.Create(monthlyAttendanceDTO);
        }

        [Authorize]
        [HttpPut]
        public async Task<int> Update(int id, MonthlyAttendanceDTO monthlyAttendanceDTO)
        {
            return await monthlyAttendanceService.Update(id, monthlyAttendanceDTO);
        }

    }
}

