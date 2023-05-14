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
    public class StudentService : IStudentService
    {
        IStudentRepo studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        public  Task<int> Create(StudentDTO entity)
        {
            Student student = Mapping.Mapper.Map<Student>(entity);
            return studentRepo.Create(student);
        }

        public Task<bool> Delete(int id)
        {
            return studentRepo.Delete(id);
        }

        public async Task<List<StudentDTO>> GetAll()
        {
                List<Student> students = await studentRepo.GetAll();
                List<StudentDTO> studentDTOs = new List<StudentDTO>();
                foreach (Student std in students)
                {
                    StudentDTO studentDTO = Mapping.Mapper.Map<StudentDTO>(std);
                    studentDTOs.Add(studentDTO);
                }
                return studentDTOs;
        }

        public  async Task<StudentDTO> GetById(int id)
        {
            Student student = await studentRepo.GetById(id);
            StudentDTO studentDTO = Mapping.Mapper.Map<StudentDTO>(student);
            return studentDTO;
        }

        public async Task<int> Update(int id, StudentDTO entity)
        {
            Student student = Mapping.Mapper.Map<Student>(entity);
            return await studentRepo.Update(id, student);
        }
    }
}
