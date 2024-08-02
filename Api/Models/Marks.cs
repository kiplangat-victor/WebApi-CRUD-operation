namespace Api.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public string? Maths { get; set; }
        public string? English { get; set; }
        public string? Kiswahili { get; set; }
        public string? Chemistry { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

    }
}