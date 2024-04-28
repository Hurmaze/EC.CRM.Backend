namespace EC.CRM.Backend.Domain.Entities
{
    public class State
    {
        public Guid Uid { get; set; }
        public required string Name { get; set; }
        public int OrderingId { get; set; }
        public List<Student>? Students { get; set; }
    }
}
