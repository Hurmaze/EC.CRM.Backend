namespace EC.CRM.Backend.Domain.Entities.TOPSIS
{
    public class MentorValuation
    {
        public Guid MentorUid { get; set; }
        public Mentor Mentor { get; set; }
        public Guid StudentUid { get; set; }
        public Student Student { get; set; }
        public bool WasSetByMentor { get; set; } = true;
        public double Valuation { get; set; }
    }
}