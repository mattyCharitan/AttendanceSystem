using AppServices.DTO;
using AutoMapper;
using Repositories.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAccount, UserDTO>();
            CreateMap<UserDTO, UserAccount>().ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            CreateMap<UserRole, RoleDTO>();
            CreateMap<RoleDTO, UserRole>();
            CreateMap<MonthlyAttendance, MonthlyAttendanceDTO>();
            CreateMap<MonthlyAttendanceDTO, MonthlyAttendance>();

        }
    }
}
