using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Student
    {
        public int Id { get; set; }
    
        public string Name { get; set; }=string.Empty;
        public string? Address { get; set;}
        public string? PhoneNumber { get; set;}
        public string? Email { get; set; }
        public List<Marks> Marks { get; set; }=new List<Marks>();

    }
}