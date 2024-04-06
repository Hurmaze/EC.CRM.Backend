namespace EC.CRM.Backend.Domain.Entities.TOPSIS
{
    public class MentorValuation
    {
        public Guid MentorUid { get; set; }
        public Guid StudentUid { get; set; }
        public double Valuation { get; set; }
    }
}