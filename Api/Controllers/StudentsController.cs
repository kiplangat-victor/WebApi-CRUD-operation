using Api.Data;
using Api.Dtos.Marks;
using Api.Dtos.Student;
using Api.Interfaces;
using Api.Interfaces.Students;
using Api.Mappers.studentsmapper;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController:ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMarkRepository _markRepository;
        private readonly IStudentRepository _studentRepository;
        public StudentsController(AppDbContext context, IMarkRepository markRepository, IStudentRepository studentRepository)
        {
            _context=context;
            _markRepository=markRepository;
            _studentRepository=studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var student=await _studentRepository.GetAllAsync();
            var studedto=student.Select(c=>c.StudentToDto());
            return Ok(studedto);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudents(StudentCreateDto student)
        {
            var data=student.DtoToStudent();
            var results=await _studentRepository.CreateAsync(data);
            return Ok (results);
            // return CreatedAtAction(nameof())
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<Student>> GetStudents(int id)
        {
            var st=await _studentRepository.GetStudentByIdAsync(id);

            // var students = await _context.Students.FindAsync(id);
            if(st==null)
            {
                return  NotFound();
            }
            var students=st.StudentToDto();
            return Ok(students);
        }
        [HttpPut("{id:int}")]
        public async Task <IActionResult> PutStudents(int id,StudentUpdateDto updateDto)
        {
            var stu=await _studentRepository.UpdateStudentByIdAsync(id, updateDto);
            if(stu==null)
            {
                return NotFound("No Records to be updated");

            }
            return Ok(stu.StudentToDto());
        }
    }
}