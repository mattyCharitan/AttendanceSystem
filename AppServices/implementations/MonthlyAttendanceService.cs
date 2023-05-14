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
    internal class MonthlyAttendanceService : IMonthlyAttendanceService
    {
        IMonthlyAttendenceRepo monthlyAttendenceRepo;

        public MonthlyAttendanceService(IMonthlyAttendenceRepo monthlyAttendenceRepo)
        {
            this.monthlyAttendenceRepo = monthlyAttendenceRepo;
        }
        public Task<int> Create(MonthlyAttendanceDTO entity)
        {
            MonthlyAttendance monthlyAttendance = Mapping.Mapper.Map<MonthlyAttendance>(entity);
            return monthlyAttendenceRepo.Create(monthlyAttendance);
        }

        public Task<bool> Delete(int id)
        {
            return monthlyAttendenceRepo.Delete(id);
        }

    public async Task<List<MonthlyAttendanceDTO>> GetAll()
        {
            List<MonthlyAttendance> monthlyAttendence = await monthlyAttendenceRepo.GetAll();
            List<MonthlyAttendanceDTO> monthlyAttendenceDTOs = new List<MonthlyAttendanceDTO>();
            foreach (MonthlyAttendance monthly in monthlyAttendence)
            {
                MonthlyAttendanceDTO monthlyAttendanceDTO = Mapping.Mapper.Map<MonthlyAttendanceDTO>(monthly);
                monthlyAttendenceDTOs.Add(monthlyAttendanceDTO);
            }
            return monthlyAttendenceDTOs;
        }

        public async Task<MonthlyAttendanceDTO> GetById(int id)
        {
            MonthlyAttendance monthlyAttendance = await monthlyAttendenceRepo.GetById(id);
            MonthlyAttendanceDTO monthlyAttendanceDTO = Mapping.Mapper.Map<MonthlyAttendanceDTO>(monthlyAttendance);
            return monthlyAttendanceDTO;
        }

        public async Task<int> Update(int id, MonthlyAttendanceDTO entity)
        {
            MonthlyAttendance monthlyAttendance = Mapping.Mapper.Map<MonthlyAttendance>(entity);
            return await monthlyAttendenceRepo.Update(id, monthlyAttendance);
        }
    }
}
