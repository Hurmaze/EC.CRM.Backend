using System.Globalization;
using EC.CRM.Backend.Application.DTOs.Models;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities.TOPSIS;
using EC.CRM.Backend.Domain.Repositories;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.IdentityModel.Tokens;

namespace EC.CRM.Backend.Application.Services.Implementation.TOPSIS
{
    public class CriteriaService : ICriteriaService
    {

        private static readonly double[] CIS = [0, 0, 0.52, 0.89, 1.11, 1.25, 1.35, 1.4, 1.45, 1.49];
        private static Random random = new Random();

        private readonly ICriteriaRepository criteriaRepository;

        public CriteriaService(ICriteriaRepository criteriaRepository)
        {
            this.criteriaRepository = criteriaRepository;
        }

        public async Task RegisterCriteriasAsync(int criteriasCount, Stream criteriasStream)
        {
            // TODO: Make it mice
            var criterias = await ParseMatrixFileAsync(criteriasCount, criteriasStream);

            var weights = CalculateCriteriaWeights(criterias.CriteriaValuations);

            for (var i = 0; i < weights.Length; i++)
            {
                Criteria criteria = new Criteria()
                {
                    IsBeneficial = criterias.IsBeneficial[i],
                    Name = criterias.CriteriasName[i],
                    Weight = weights[i]
                };

                await criteriaRepository.AddOrUpdateCriteriaAsync(criteria);
            }
        }

        private double[] CalculateCriteriaWeights(List<CriteriaValuation> criterias)
        {
            List<double[]> weights = new();

            foreach (var criteria in criterias)
            {
                weights.Add(CalculateWeights(criteria.Valuations!));
            }

            double[] resultWeights = new double[weights[0].Length];
            for (int i = 0; i < weights[0].Length; i++)
            {
                for (int j = 0; j < weights.Count; j++)
                {
                    resultWeights[i] += weights[j][i];
                }

                resultWeights[i] /= weights.Count;
            }

            return resultWeights;
        }

        private async Task<CriteriasValuationResult> ParseMatrixFileAsync(int criteriasCount, Stream criteriasStream)
        {
            List<CriteriaValuation> criteriasValuations = new();

            bool wasInitialized = false;
            bool[] isBeneficial = new bool[criteriasCount];
            string[] criteriasName = new string[criteriasCount];

            CriteriaValuation criteriasValuation = new() { Valuations = new double[criteriasCount, criteriasCount] };
            string? currentLine;
            int currentLineCount = 0;

            using StreamReader sr = new(criteriasStream);
            while ((currentLine = sr.ReadLine()) != null)
            {
                string[] line = currentLine.Split(',').Where(x => !x.IsNullOrEmpty()).ToArray();

                if (!line.Any())
                {
                    criteriasValuations.Add(criteriasValuation);
                    criteriasValuation = new() { Valuations = new double[criteriasCount, criteriasCount] };

                    continue;
                }

                if (!double.TryParse(line[0], CultureInfo.InvariantCulture, out double result))
                {

                    if (!wasInitialized)
                    {
                        isBeneficial = line.Skip(1).Select(x => Convert.ToBoolean(x, CultureInfo.InvariantCulture)).ToArray();

                        currentLine = sr.ReadLine();
                        line = currentLine!.Split(',').Where(x => !x.IsNullOrEmpty()).ToArray();

                        criteriasValuation.MentorName = line[0];
                        criteriasName = line.Skip(1).ToArray();

                        wasInitialized = true;
                    }
                    else
                    {
                        criteriasValuation.MentorName = line[0];
                    }
                }
                else
                {
                    double[] row = line.Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray();

                    criteriasValuation.Valuations.SetRow(
                        (currentLineCount - 1 - criteriasValuations.Count) % criteriasCount,
                        row);
                }

                currentLineCount++;
            }

            criteriasValuations.Add(criteriasValuation);

            return new CriteriasValuationResult()
            {
                CriteriasName = criteriasName,
                CriteriaValuations = criteriasValuations,
                IsBeneficial = isBeneficial,
            };
        }

        public static double SimpleVectorIteration(double[,] matrix, int maxIterations = 1000, double tolerance = 1E-06)
        {
            Matrix<double> A = DenseMatrix.OfArray(matrix);

            var x = CreateVector.DenseOfArray(Enumerable.Repeat(0, matrix.GetLength(0))
                .Select(i => random.NextDouble())
                .ToArray());
            var xReport = CreateVector.DenseOfArray(Enumerable.Repeat(0, matrix.GetLength(0))
                .Select(i => 1.0)
                .ToArray());

            x /= x.L2Norm();
            var xLog = new List<Vector<double>>();
            var vecLog = new List<Vector<double>>();

            int iteration = 0;
            do
            {
                var aX = A * x;
                var aReport = A * xReport;
                vecLog.Add(aReport);

                var xNew = aX / aX.L2Norm();

                if ((xNew - x).L2Norm() < tolerance) break;

                xLog.Add(aReport / xReport);
                xReport = aReport;

                x = xNew;
                iteration++;

            } while (iteration < maxIterations);

            var maxCharacteristicNumber = CalculateMaxCharacteristicNumber(A, x);

            return maxCharacteristicNumber;
        }

        private static double CalculateMaxCharacteristicNumber(Matrix<double> matrix, Vector<double> x) => x * matrix * x;
        private static double CalculateCI(double maxCharNum, int criteriaCount) => (maxCharNum - criteriaCount) / (criteriaCount - 1);
        private static double CalculateCR(double CI, int criteriaCount) => CI / CIS[criteriaCount - 1];
        private static double[] CalculateWeights(double[,] alternatives)
        {
            int lenght = alternatives.GetLength(0);
            double[] weights = new double[lenght];

            for (int i = 0; i < lenght; i++)
            {
                double product = 1.0;
                for (int j = 0; j < lenght; j++)
                {
                    product *= alternatives[i, j];
                }

                weights[i] = Math.Pow(product, (1.0 / lenght));
            }

            return NormalizeVector(weights);
        }

        private static double[] NormalizeVector(double[] vector)
        {
            var vecSum = vector.Sum();
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] / vecSum;
            }

            return vector;
        }

        public static double[] Multiply(double[] a, List<double[]> b)
        {
            var list = b.Select(x => CreateVector.DenseOfArray(x));
            var aMatrix = CreateMatrix.DenseOfColumnVectors(list);

            return (CreateVector.DenseOfArray(a) * aMatrix.Transpose()).ToArray();
        }
    }
}
