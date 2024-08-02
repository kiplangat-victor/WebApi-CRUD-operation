
using Api.Dtos.Marks;

namespace Api.Dtos.Student
{
    public class StudentsDto
    {
        public int Id { get; set; }
    
        public string Name { get; set; }=string.Empty;
        public string? Address { get; set;}
        public string? PhoneNumber { get; set;}
        public string? Email { get; set; }
        public List<MarksDto> Marks { get; set; }=new List<MarksDto>();
    }
}