namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface ITopsisAlgorithm
    {
        Dictionary<int, double> Calculate(double[,] decisionMatrix, double[] weights, bool[] isBeneficial);
        void Validate(double[,] decisionMatrix, double[] weights, bool[] isBeneficial);
    }
}