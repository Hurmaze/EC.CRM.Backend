namespace EC.CRM.Backend.Domain.Entities
{
    public class Mentor
    {
        public int Uid { get; set; }
        public required UserInfo UserInfo { get; set; }
        public List<Student>? Students { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
