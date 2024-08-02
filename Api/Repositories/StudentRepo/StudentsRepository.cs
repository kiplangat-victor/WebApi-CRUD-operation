using Api.Data;
using Api.Models;
using Api.Interfaces.Students;
using Microsoft.EntityFrameworkCore;
using Api.Dtos.Student;
using Api.Dtos.Marks;

namespace Api.Repositories.StudentRepo
{
    public class StudentsRepository : IStudentRepository
    {    
        private readonly AppDbContext _dbContext;
        public StudentsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> CreateAsync(Student student)
        {
          await _dbContext.Students.AddAsync(student);
           await _dbContext.SaveChangesAsync();
           return student;
        }

        public Task<List<Student>> GetAllAsync()
        {
            return  _dbContext.Students.Include(c=>c.Marks).ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _dbContext.Students.Include(x=>x.Marks).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Student> UpdateStudentByIdAsync(int id, StudentUpdateDto student)
        {
           var studentss=await _dbContext.Students.Include(x=>x.Marks).FirstOrDefaultAsync(x=>x.Id==id);
           if(studentss==null)
           {
            return null;
           }
           studentss.Name=student.Name;
           studentss.Address=student.Address;
           studentss.PhoneNumber=student.PhoneNumber;
           studentss.Email=student.Email;
           await _dbContext.SaveChangesAsync();
           return studentss;
        }
    }
}