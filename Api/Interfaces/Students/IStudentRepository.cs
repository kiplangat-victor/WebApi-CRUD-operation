using Api.Dtos.Marks;
using Api.Dtos.Student;
using Api.Models;

namespace Api.Interfaces.Students
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> UpdateStudentByIdAsync(int id, StudentUpdateDto student);
        // Task<Student> DeleteStudentByIdAsync(int id);
        Task<Student> CreateAsync(Student student);


    }
}