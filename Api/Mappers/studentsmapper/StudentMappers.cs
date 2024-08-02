using Api.Dtos.Student;
using Api.Models;

namespace Api.Mappers.studentsmapper
{
    public static class StudentMappers
    {
        public static Student DtoToStudent(this StudentCreateDto studentsDto)
        {
            return new Student{
                // Id = studentsDto.Id,
                Name = studentsDto.Name,
                Address=studentsDto.Address,
                PhoneNumber=studentsDto.PhoneNumber,
                Email=studentsDto.Email,

            };

        }
        public static StudentsDto StudentToDto(this Student student)
        {
             return new StudentsDto{
                Id = student.Id,
                Name = student.Name,
                Address=student.Address,
                PhoneNumber=student.PhoneNumber,
                Email=student.Email,
                Marks=student.Marks.Select(c=>c.MarksToDto()).ToList(),

            };

        }
        public static Student UpdateDtoToStudent(this StudentUpdateDto studentUpdate)
        {
            return new Student{
                Name=studentUpdate.Name,
                Email=studentUpdate.Email,
                Address=studentUpdate.Address,
                PhoneNumber=studentUpdate.PhoneNumber
            };
        }
    }
}