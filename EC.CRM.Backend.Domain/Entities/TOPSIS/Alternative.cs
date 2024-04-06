namespace EC.CRM.Backend.Domain.Entities.TOPSIS
{
    public class Alternative
    {
        public required string Name { get; set; }
        public required double Weight { get; set; }
        public required bool IsBeneficial { get; set; }
    }
}
