using EC.CRM.Backend.Application.Services.Interfaces;

namespace EC.CRM.Backend.Application.Services.Implementation.TOPSIS
{
    public class TopsisAlgorithm : ITopsisAlgorithm
    {
        public TopsisAlgorithm() { }

        public Dictionary<int, double> Calculate(double[,] decisionMatrix, double[] weights, bool[] isBeneficial)
        {
            decisionMatrix = NormalizeMatrix(decisionMatrix);

            decisionMatrix = ApplyWeights(decisionMatrix, weights);

            double[] positiveIdeal = GetIdealSolution(decisionMatrix, isBeneficial, true);
            double[] negativeIdeal = GetIdealSolution(decisionMatrix, isBeneficial, false);

            double[] distanceToPositive = CalculateDistances(decisionMatrix, positiveIdeal);
            double[] distanceToNegative = CalculateDistances(decisionMatrix, negativeIdeal);

            // Step 5: Calculate the relative closeness to the ideal solution
            double[] relativeCloseness = CalculateRelativeCloseness(distanceToPositive, distanceToNegative);

            return CalculateRankins(relativeCloseness);
        }

        public static double[,] NormalizeMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] normalizedMatrix = new double[rows, cols];

            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    sum += matrix[i, j] * matrix[i, j];
                }
                double norm = Math.Sqrt(sum);
                for (int i = 0; i < rows; i++)
                {
                    normalizedMatrix[i, j] = matrix[i, j] / norm;
                }
            }

            return normalizedMatrix;
        }

        public static double[,] ApplyWeights(double[,] matrix, double[] weights)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] weightedMatrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    weightedMatrix[i, j] = matrix[i, j] * weights[j];
                }
            }

            return weightedMatrix;
        }

        public static double[] GetIdealSolution(double[,] matrix, bool[] beneficial, bool positive)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] idealSolution = new double[cols];

            for (int j = 0; j < cols; j++)
            {
                double[] columnValues = new double[rows];
                for (int i = 0; i < rows; i++)
                {
                    columnValues[i] = matrix[i, j];
                }

                if (positive)
                {
                    idealSolution[j] = beneficial[j] ? columnValues.Max() : columnValues.Min();
                }
                else
                {
                    idealSolution[j] = beneficial[j] ? columnValues.Min() : columnValues.Max();
                }
            }

            return idealSolution;
        }

        public static double[] CalculateDistances(double[,] matrix, double[] idealSolution)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] distances = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += Math.Pow(matrix[i, j] - idealSolution[j], 2);
                }
                distances[i] = Math.Sqrt(sum);
            }

            return distances;
        }

        public static double[] CalculateRelativeCloseness(double[] distanceToPositive, double[] distanceToNegative)
        {
            int length = distanceToPositive.Length;
            double[] relativeCloseness = new double[length];

            for (int i = 0; i < length; i++)
            {
                relativeCloseness[i] = distanceToNegative[i] / (distanceToPositive[i] + distanceToNegative[i]);
            }

            return relativeCloseness;
        }

        private Dictionary<int, double> CalculateRankins(double[] closenessCoefficients)
        {
            var alternativesCount = closenessCoefficients.Length;

            return closenessCoefficients.ToDictionary(i => Array.IndexOf(closenessCoefficients, i))
                .OrderByDescending(c => c.Value)
                .ToDictionary(c => c.Key, c => c.Value);
        }
    }
}
