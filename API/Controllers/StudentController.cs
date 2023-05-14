using AppServices.DTO;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class StudentController : AttendenceBaseController
    {
        IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<List<StudentDTO>> GetAll()
        {
            return await studentService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<StudentDTO> Get(int id)
        {
            return await studentService.GetById(id);
        }

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

        [HttpPut]

        public async Task<int> Update(int id, StudentDTO studentDTO)
        {
            return await studentService.Update(id, studentDTO);
        }
    }
}
