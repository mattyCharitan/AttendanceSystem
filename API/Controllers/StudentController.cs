using AppServices.DTO;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    
    public class StudentController : AttendenceBaseController
    {
        IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<List<StudentDTO>> GetAll()
        {
            return await studentService.GetAll();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<StudentDTO> Get(int id)
        {
            return await studentService.GetById(id);
        }

        [Authorize]
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await studentService.Delete(id);
        }

        [HttpPost]

        public async Task<int> Create(StudentDTO studentDTO)
        {
            return await studentService.Create(studentDTO);
        }

        [Authorize]
        [HttpPut]

        public async Task<int> Update(int id, StudentDTO studentDTO)
        {
            return await studentService.Update(id, studentDTO);
        }
    }
}
