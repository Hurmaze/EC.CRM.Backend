namespace EC.CRM.Backend.Domain.Entities.TOPSIS
{
    public class Criteria
    {
        public required string Name { get; set; }
        public double? Weight { get; set; }
        public required bool IsBeneficial { get; set; }
    }
}
