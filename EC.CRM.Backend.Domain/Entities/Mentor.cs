namespace EC.CRM.Backend.Domain.Entities
{
    public class Mentor
    {
        public Guid Uid { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? CurentSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Job>? Jobs { get; set; }
        public List<Student>? Students { get; set; }
    }
}
