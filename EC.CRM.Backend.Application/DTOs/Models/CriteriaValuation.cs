namespace EC.CRM.Backend.Application.DTOs.Models
{
    public class CriteriasValuationResult
    {
        public required string[] CriteriasName { get; set; }
        public required bool[] IsBeneficial { get; set; }
        public required List<CriteriaValuation> CriteriaValuations { get; set; }
    }

    public class CriteriaValuation
    {
        public string[]? CriteriasName { get; set; }
        public string? MentorName { get; set; }
        public double[,]? Valuations { get; set; }
    }
}
