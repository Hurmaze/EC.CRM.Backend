using EC.CRM.Backend.Application.Services.Interfaces;

namespace EC.CRM.Backend.Application.Services.Implementation.TOPSIS
{
    public class TopsisAlgorithm : ITopsisAlgorithm
    {
        public TopsisAlgorithm() { }

        public void Validate(double[,] decisionMatrix, double[] weights, bool[] isBeneficial)
        {
            if (decisionMatrix.GetLength(0) == 0 || decisionMatrix.GetLength(1) == 0)
                throw new ArgumentException("Decision matrix cannot be empty");

            if (decisionMatrix.GetLength(1) != weights.Length || decisionMatrix.GetLength(0) != isBeneficial.Length)
                throw new ArgumentException("Invalid input sizes");
        }

        public Dictionary<int, double> Calculate(double[,] decisionMatrix, double[] weights, bool[] isBeneficial)
        {
            Validate(decisionMatrix, weights, isBeneficial);

            decisionMatrix = NormalizeMatrix(decisionMatrix);

            decisionMatrix = WeightNormalize(decisionMatrix, weights);

            var idealSolutions = CalculateBestAndWorseSolution(decisionMatrix, isBeneficial);

            var distances = CalculateEuclideanDistances(decisionMatrix, idealSolutions.bestSolution, idealSolutions.worseSolution);

            var closenessCoefficients = CalculateClosenessCoefficient(distances.positiveDistances, distances.negativeDistances);

            return CalculateRankins(closenessCoefficients);
        }

        private double[,] NormalizeMatrix(double[,] matrix)
        {
            var alternativesCount = matrix.GetLength(0);
            var criteriasCount = matrix.GetLength(1);

            double[,] normalizedMatrix = new double[alternativesCount, criteriasCount];
            for (int i = 0; i < alternativesCount; i++)
            {
                for (int j = 0; j < criteriasCount; j++)
                {
                    normalizedMatrix[i, j] = matrix[i, j] / Norm(matrix, j);
                }
            }

            return normalizedMatrix;
        }

        private double Norm(double[,] matrix, int column)
        {
            double sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += Math.Pow(matrix[i, column], 2);
            }
            return Math.Sqrt(sum);
        }

        private double[,] WeightNormalize(double[,] normalizedMatrix, double[] weights)
        {
            var alternativesCount = normalizedMatrix.GetLength(0);
            var criteriasCount = normalizedMatrix.GetLength(1);

            double[,] weightedNormalizedMatrix = new double[alternativesCount, criteriasCount];
            for (int i = 0; i < alternativesCount; i++)
            {
                for (int j = 0; j < criteriasCount; j++)
                {
                    weightedNormalizedMatrix[i, j] = normalizedMatrix[i, j] * weights[j];
                }
            }

            return weightedNormalizedMatrix;
        }

        private (double[] bestSolution, double[] worseSolution) CalculateBestAndWorseSolution(
            double[,] weightedNormalizedMatrix,
            bool[] isBeneficial)
        {
            var criteriasCount = weightedNormalizedMatrix.GetLength(1);

            double[] idealSolution = new double[criteriasCount];
            double[] negativeIdealSolution = new double[criteriasCount];
            for (int j = 0; j < criteriasCount; j++)
            {
                idealSolution[j] = isBeneficial[j] ? weightedNormalizedMatrix.GetColumn(j).Max() : weightedNormalizedMatrix.GetRow(j).Min();
                negativeIdealSolution[j] = isBeneficial[j] ? weightedNormalizedMatrix.GetColumn(j).Min() : weightedNormalizedMatrix.GetRow(j).Max();
            }

            return (idealSolution, negativeIdealSolution);
        }

        private (double[] positiveDistances, double[] negativeDistances) CalculateEuclideanDistances(
            double[,] weightedNormalizedMatrix,
            double[] idealSolution,
            double[] negativeIdealSolution)
        {
            var alternativesCount = weightedNormalizedMatrix.GetLength(0);
            var criteriasCount = weightedNormalizedMatrix.GetLength(1);

            double[] positiveDistances = new double[alternativesCount];
            double[] negativeDistances = new double[alternativesCount];
            for (int i = 0; i < alternativesCount; i++)
            {
                positiveDistances[i] = Math.Sqrt(weightedNormalizedMatrix.GetRow(i).Select((x, j) => Math.Pow(x - idealSolution[j], 2)).Sum());
                negativeDistances[i] = Math.Sqrt(weightedNormalizedMatrix.GetRow(i).Select((x, j) => Math.Pow(x - negativeIdealSolution[j], 2)).Sum());
            }

            return (positiveDistances, negativeDistances);
        }

        private double[] CalculateClosenessCoefficient(double[] positiveDistances, double[] negativeDistances)
        {
            var alternativesCount = positiveDistances.Length;

            double[] closenessCoefficient = new double[alternativesCount];
            for (int i = 0; i < alternativesCount; i++)
            {
                closenessCoefficient[i] = negativeDistances[i] / (negativeDistances[i] + positiveDistances[i]);
            }

            return closenessCoefficient;
        }

        private Dictionary<int, double> CalculateRankins(double[] closenessCoefficients)
        {
            var alternativesCount = closenessCoefficients.Length;

            return closenessCoefficients.ToDictionary(i => Array.IndexOf(closenessCoefficients, i))
                .OrderBy(c => c.Value)
                .ToDictionary(c => c.Key, c => c.Value);
        }
    }
}
